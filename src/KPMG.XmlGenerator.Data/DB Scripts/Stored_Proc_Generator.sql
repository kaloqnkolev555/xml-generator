SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

DECLARE @DBName nvarchar(100)=N'_META_XML_GENERATOR_PROD_GENERIC'
DECLARE @TableName VARCHAR(100)
DECLARE @TableSchema VARCHAR(100)
DECLARE @PRIMARY_KEY nvarchar(100)
DECLARE @OutputParamKey nvarchar(100)

SET @PRIMARY_KEY = 'IdColumn'
SET @OutputParamKey = 'NewIdColumn'

DECLARE @NNND char(23) ='NOT_NULLABLE_NO_DEFAULT';
DECLARE @NNWD char(22) ='NOT_NULLABLE_W_DEFAULT';
DECLARE @NBLE char(8) ='NULLABLE';

DECLARE @HEADER nvarchar(max);
DECLARE @AUTHOR nvarchar(50) ='';
SET @HEADER = N'SET ANSI_NULLS ON' + CHAR(13) + CHAR(10) 
SET @HEADER = @HEADER + N'GO' + CHAR(13) + CHAR(10) 
SET @HEADER = @HEADER + CHAR(13) + CHAR(10) 
SET @HEADER = @HEADER + N'SET QUOTED_IDENTIFIER ON' + CHAR(13) + CHAR(10) 
SET @HEADER = @HEADER + N'GO' + CHAR(13) + CHAR(10) 
SET @HEADER = @HEADER + CHAR(13) + CHAR(10) 
SET @HEADER = @HEADER + N'-- ===================================================================' + CHAR(13) + CHAR(10) 
SET @HEADER = @HEADER + N'-- Author      : ' + @AUTHOR + CHAR(13) + CHAR(10) 
SET @HEADER = @HEADER + N'-- Create date : ' + CONVERT(nvarchar(30),GETDATE(),101) + CHAR(13) + CHAR(10) 
SET @HEADER = @HEADER + N'-- Revised date: ' + CHAR(13) + CHAR(10) 

DECLARE CursorMetaTables CURSOR FOR
  SELECT TABLE_SCHEMA,
         TABLE_NAME
  FROM   INFORMATION_SCHEMA.TABLES
  WHERE  TABLE_TYPE = 'BASE TABLE'and TABLE_NAME LIKE 'cg_meta%' AND TABLE_NAME <> 'cg_meta_version' AND TABLE_NAME <> 'cg_meta_trigger_logfile'

OPEN CursorMetaTables

FETCH NEXT FROM CursorMetaTables INTO @TableSchema,@TableName

WHILE @@FETCH_STATUS = 0
  BEGIN
	DECLARE TableCol Cursor FOR 
	SELECT c.COLUMN_NAME, c.DATA_TYPE, c.CHARACTER_MAXIMUM_LENGTH
		, IIF(c.COLUMN_NAME='RowVersion',@NBLE,IIF(c.COLUMN_NAME=@PRIMARY_KEY,@NBLE,IIF(c.IS_NULLABLE = 'NO' AND c.COLUMN_DEFAULT IS NULL,@NNND,IIF(c.IS_NULLABLE = 'NO' AND c.COLUMN_DEFAULT IS NOT NULL,@NNWD,@NBLE)))) AS [NULLABLE_TYPE]
	FROM INFORMATION_SCHEMA.Columns c INNER JOIN
		INFORMATION_SCHEMA.Tables t ON c.TABLE_NAME = t.TABLE_NAME
	WHERE t.Table_Catalog = @DBName
		AND t.TABLE_TYPE = 'BASE TABLE'
		AND t.TABLE_NAME = @TableName
	ORDER BY c.ORDINAL_POSITION;

	DECLARE @ColumnName varchar(100);
	DECLARE @DataType varchar(30), @CharLength int, @NullableType varchar(30);

	DECLARE @PARAMETERS nvarchar(max);
	DECLARE @INSERT_FIELDS nvarchar(max),@INSERT_VALUES nvarchar(max);
	DECLARE @UPDATE_VALUES nvarchar(max);

	SET @PARAMETERS ='';
	SET @INSERT_FIELDS ='';
	SET @INSERT_VALUES ='';
	SET @UPDATE_VALUES ='';

	OPEN TableCol

	FETCH NEXT FROM TableCol INTO @ColumnName, @DataType, @CharLength, @NullableType

	WHILE @@FETCH_STATUS = 0
	BEGIN
			SET @PARAMETERS=@PARAMETERS + '@' + @ColumnName + ' ' + iif(@CharLength IS NULL,@DataType,@DataType + '(' + 
					iif(@CharLength=-1,'MAX',CAST(@CharLength AS nvarchar(10))) + ')') + IIF(@NullableType=@NNND OR @NullableType=@NNWD,',','=NULL,');

			IF @ColumnName <> @PRIMARY_KEY AND @ColumnName <> N'RowVersion'
			BEGIN
				SET @INSERT_FIELDS=@INSERT_FIELDS + '[' + @ColumnName + '],';
				SET @INSERT_VALUES=@INSERT_VALUES + '@' + @ColumnName + ',';
				SET @UPDATE_VALUES=@UPDATE_VALUES + '[' + @ColumnName + ']=@' + @ColumnName + ',';
			END			

			FETCH NEXT FROM TableCol INTO @ColumnName, @DataType, @CharLength, @NullableType
	END;
	CLOSE TableCol;
	DEALLOCATE TableCol;

	SET @PARAMETERS=@PARAMETERS + '@' + @OutputParamKey + ' int OUTPUT'
	SET @INSERT_FIELDS=LEFT(@INSERT_FIELDS,LEN(@INSERT_FIELDS)-1)
	SET @INSERT_VALUES=LEFT(@INSERT_VALUES,LEN(@INSERT_VALUES)-1)
	SET @UPDATE_VALUES=LEFT(@UPDATE_VALUES,LEN(@UPDATE_VALUES)-1)

	PRINT N'/****** Object:  StoredProcedure [dbo].[usp_' + @TableName + '_ups]    Script Date: ' + CAST(GETDATE() AS nvarchar(30)) + '  ******/' + CHAR(13) + CHAR(10) 
	PRINT N'IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N''[dbo].[usp_' + @TableName + '_ups]'') AND OBJECTPROPERTY(id, N''IsProcedure'') = 1)' + CHAR(13) + CHAR(10) 
	PRINT N'BEGIN' + CHAR(13) + CHAR(10)
	PRINT N'   DROP PROCEDURE [dbo].[usp_' + @TableName + '_ups]' + CHAR(13) + CHAR(10)
	PRINT N'END' + CHAR(13) + CHAR(10)

	PRINT @HEADER;
	PRINT N'-- Description : Upsert ' + CHAR(13) + CHAR(10) 
	PRINT N'-- ===================================================================' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 
	PRINT N'CREATE PROCEDURE [dbo].[usp_' + @TableName +   + '_ups]' + CHAR(13) + CHAR(10);
	PRINT N'  (' + @PARAMETERS + N')' + CHAR(13) + CHAR(10);
	PRINT N'AS' + CHAR(13) + CHAR(10) 
	PRINT N'BEGIN' + CHAR(13) + CHAR(10) 
	PRINT N'  SET NOCOUNT ON' + CHAR(13) + CHAR(10) 
	PRINT N'  SET XACT_ABORT ON' + CHAR(13) + CHAR(10) 
	PRINT N'  BEGIN TRAN' + CHAR(13) + CHAR(10) 
	PRINT N'  IF @' + @PRIMARY_KEY + ' IS NULL OR @' + @PRIMARY_KEY + ' = 0' + CHAR(13) + CHAR(10) 
	PRINT N'    BEGIN' + CHAR(13) + CHAR(10) 
	PRINT N'      INSERT INTO [dbo].[' + @TableName + ']' + CHAR(13) + CHAR(10) 
	PRINT N'        (' + @INSERT_FIELDS + N')' + CHAR(13) + CHAR(10) 
	PRINT N'      VALUES' + CHAR(13) + CHAR(10) 
	PRINT N'        (' + @INSERT_VALUES + N');' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 
	PRINT N'      SELECT @' + @OutputParamKey + ' = SCOPE_IDENTITY();' + CHAR(13) + CHAR(10)	
	PRINT N'    END' + CHAR(13) + CHAR(10) 
	PRINT N'  ELSE' + CHAR(13) + CHAR(10) 
	PRINT N'    BEGIN' + CHAR(13) + CHAR(10) 
	PRINT N'      UPDATE [dbo].[' + @TableName + ']' + CHAR(13) + CHAR(10) 
	PRINT N'        SET ' + @UPDATE_VALUES + CHAR(13) + CHAR(10) 
	PRINT N'        WHERE ([' + @PRIMARY_KEY + '] = @' + @PRIMARY_KEY +');' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 
	PRINT N'      SELECT @' + @OutputParamKey + ' = @' + @PRIMARY_KEY + ';' + CHAR(13) + CHAR(10)	
	PRINT N'    END' + CHAR(13) + CHAR(10)
	PRINT N'  COMMIT' + CHAR(13) + CHAR(10)  
	PRINT N'END' + CHAR(13) + CHAR(10) 
	PRINT N'GO' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 

	PRINT N'/****** Object:  StoredProcedure [dbo].[usp_' + @TableName + '_sel]    Script Date: ' + CAST(GETDATE() AS nvarchar(30)) + '  ******/' + CHAR(13) + CHAR(10) 
	PRINT N'IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N''[dbo].[usp_' + @TableName + '_sel]'') AND OBJECTPROPERTY(id, N''IsProcedure'') = 1)' + CHAR(13) + CHAR(10) 
	PRINT N'BEGIN' + CHAR(13) + CHAR(10)
	PRINT N'   DROP PROCEDURE [dbo].[usp_' + @TableName + '_sel]' + CHAR(13) + CHAR(10)
	PRINT N'END' + CHAR(13) + CHAR(10)

	PRINT @HEADER;
	PRINT N'-- Description : Select ' + CHAR(13) + CHAR(10) 
	PRINT N'-- ===================================================================' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 
	PRINT N'CREATE PROCEDURE [dbo].[usp_' + @TableName + '_sel]' + CHAR(13) + CHAR(10);
	PRINT N'  (@' + @PRIMARY_KEY + ' int=NULL)' + CHAR(13) + CHAR(10);
	PRINT N'AS' + CHAR(13) + CHAR(10) 
	PRINT N'BEGIN' + CHAR(13) + CHAR(10) 
	PRINT N'  SET NOCOUNT ON' + CHAR(13) + CHAR(10) 
	PRINT N'  SET XACT_ABORT ON' + CHAR(13) + CHAR(10) 
	PRINT N'  BEGIN TRAN' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 
	PRINT N'  IF @' + @PRIMARY_KEY + ' IS NULL OR @' + @PRIMARY_KEY + ' = 0' + CHAR(13) + CHAR(10) 
	PRINT N'    SELECT * FROM [dbo].[' + @TableName + '] ORDER BY IdColumn;' + CHAR(13) + CHAR(10)
	PRINT N'  ELSE' + CHAR(13) + CHAR(10) 
	PRINT N'    SELECT * FROM [dbo].[' + @TableName + '] WHERE [IdColumn] = @' + @PRIMARY_KEY + ';' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 
	PRINT N'  COMMIT' + CHAR(13) + CHAR(10)  
	PRINT N'END' + CHAR(13) + CHAR(10) 
	PRINT N'GO' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 

	PRINT N'/****** Object:  StoredProcedure [dbo].[usp_' + @TableName + '_del]    Script Date: ' + CAST(GETDATE() AS nvarchar(30)) + '  ******/' + CHAR(13) + CHAR(10) 
    PRINT N'IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N''[dbo].[usp_' + @TableName + '_del]'') AND OBJECTPROPERTY(id, N''IsProcedure'') = 1)' + CHAR(13) + CHAR(10) 
	PRINT N'BEGIN' + CHAR(13) + CHAR(10)
	PRINT N'   DROP PROCEDURE [dbo].[usp_' + @TableName + '_del]' + CHAR(13) + CHAR(10)
	PRINT N'END' + CHAR(13) + CHAR(10)

	PRINT @HEADER;
	PRINT N'-- Description : Delete ' + CHAR(13) + CHAR(10) 
	PRINT N'-- ===================================================================' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 
	PRINT N'CREATE PROCEDURE [dbo].[usp_' + @TableName  + '_del]' + CHAR(13) + CHAR(10);
	PRINT N'  (@' + @PRIMARY_KEY + ' int)' + CHAR(13) + CHAR(10);
	PRINT N'AS' + CHAR(13) + CHAR(10) 
	PRINT N'BEGIN' + CHAR(13) + CHAR(10) 
	PRINT N'  SET NOCOUNT ON' + CHAR(13) + CHAR(10) 
	PRINT N'  SET XACT_ABORT ON' + CHAR(13) + CHAR(10) 
	PRINT N'  BEGIN TRAN' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 
	PRINT N'  DELETE FROM [dbo].[' + @TableName + '] WHERE [' + @PRIMARY_KEY + ']=@' + @PRIMARY_KEY + ';' + CHAR(13) + CHAR(10) 
	PRINT N'  SELECT @@ROWCOUNT as [Rows Affected];' + CHAR(13) + CHAR(10)
	PRINT CHAR(13) + CHAR(10)  
	PRINT N'  COMMIT' + CHAR(13) + CHAR(10)  
	PRINT N'END' + CHAR(13) + CHAR(10) 
	PRINT N'GO' + CHAR(13) + CHAR(10) 
	PRINT CHAR(13) + CHAR(10) 
	  
    FETCH NEXT FROM CursorMetaTables INTO @TableSchema,@TableName
  END

CLOSE CursorMetaTables
DEALLOCATE CursorMetaTables