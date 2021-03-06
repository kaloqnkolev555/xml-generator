SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_column_by_obj_area_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_column_by_obj_area_sel];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 03/10/2019
-- Revised date:
-- Description : Select from [dbo].[cg_meta_column]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_column_by_obj_area_sel]
  (@ref_version_id int, @objct_name nvarchar(255), @area_name nvarchar(255))
AS
BEGIN
  SET NOCOUNT ON

  IF @objct_name IS NOT NULL AND LEN(@objct_name) > 0 AND @area_name IS NOT NULL AND LEN(@area_name) > 0
  BEGIN
	SELECT
		[c].[IdColumn] AS [Id],
		[c].[ref_version_id] AS [VersionId],
		[c].[column_name] AS [ColumnName],
		[dd03l].[TABNAME] AS [TableName],
		[dd03l].[KEYFLAG]
	FROM [dbo].[cg_meta_column] (NOLOCK) AS c
	INNER JOIN [dbo].[cg_meta_objct] (NOLOCK) AS o on [o].[ref_version_id] = [c].[ref_version_id] AND [o].[objct_name] = [c].[ref_objct_name]
	INNER JOIN [dbo].[DD03L] (NOLOCK) AS dd03l ON [dd03l].[TABNAME] = [o].[ref_table_name] AND [dd03l].[FIELDNAME] = [c].[column_name]
	WHERE [c].[ref_version_id] = @ref_version_id AND [c].[ref_objct_name] = @objct_name AND [c].[ref_area_name] = @area_name
	AND [o].[ref_table_name] IS NOT NULL AND LEN([o].[ref_table_name]) > 0
	ORDER BY [dd03l].[KEYFLAG] DESC, [c].[column_name];
  END
END
