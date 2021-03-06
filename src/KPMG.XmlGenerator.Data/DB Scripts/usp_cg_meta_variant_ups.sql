SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_variant_ups]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_variant_ups];
GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 02/09/2019
-- Revised date: 27/09/2019
-- Description : Update 
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_variant_ups]
  (@ref_version_id int,@variant_name nvarchar(255),@MapMetaObjctIdColumns nvarchar(max)=NULL,@IdColumn int=NULL,@NewIdColumn int OUTPUT, @ErrorCode int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON
  SET XACT_ABORT ON
  BEGIN TRAN

	IF @IdColumn is NOT NULL
	BEGIN
	
		-- fetch variant name and variant/object version
		SELECT @ref_version_id = [ref_version_id], @variant_name = [variant_name] FROM [dbo].[cg_meta_variant] WHERE [IdColumn] = @IdColumn;

		-- Check if variant exists
		IF @variant_name IS NOT NULL AND LEN(LTRIM(@variant_name)) > 0
		BEGIN
	  
		  IF @MapMetaObjctIdColumns IS NULL OR LEN(LTRIM(@MapMetaObjctIdColumns)) = 0
          BEGIN
		  -- delete mappings
		    DELETE [dbo].[cg_meta_variant_objct]
			  WHERE [ref_version_id] = @ref_version_id
				    AND [ref_variant_name] = @variant_name;
            RETURN;
          END

          
          SET @MapMetaObjctIdColumns = ','+@MapMetaObjctIdColumns+',';

          DECLARE @objct_names TABLE([objct_name] nvarchar(255));

          INSERT INTO @objct_names ([objct_name])
            SELECT [objct_name]
              FROM [dbo].[cg_meta_objct]
              WHERE CHARINDEX(','+cast([IdColumn] as varchar(30))+',', @MapMetaObjctIdColumns) > 0;

          -- delete unmapped
		  DELETE [dbo].[cg_meta_variant_objct]
			WHERE [ref_version_id] = @ref_version_id
				AND [ref_variant_name] = @variant_name
                AND [ref_objct_name] NOT IN (SELECT [objct_name] FROM @objct_names);

          -- insert newly mapped
          INSERT INTO [dbo].[cg_meta_variant_objct]
            ([ref_version_id], [ref_variant_name], [ref_objct_name], [ref_extraction_logic_name])
            SELECT DISTINCT @ref_version_id, @variant_name, ob.[objct_name], (SELECT MAX([ref_extraction_logic_name]) FROM [dbo].[cg_meta_technical_setting] WHERE [ref_objct_name] = ob.[objct_name] AND [ref_version_id] = @ref_version_id)
              FROM @objct_names AS ob
              WHERE ob.[objct_name] NOT IN (SELECT [ref_objct_name] FROM [dbo].[cg_meta_variant_objct] WHERE [ref_version_id] = @ref_version_id AND [ref_variant_name] = @variant_name);

		END
		ELSE
			SELECT @ErrorCode = 201; -- variant name is missing
	END
	ELSE 
		SELECT @ErrorCode = 204; --id column is missing

  COMMIT
END

