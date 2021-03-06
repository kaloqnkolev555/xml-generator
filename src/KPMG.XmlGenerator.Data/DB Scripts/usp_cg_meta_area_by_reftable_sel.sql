SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_area_by_reftable_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_area_by_reftable_sel];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 01/10/2019
-- Revised date:
-- Description : Select from [dbo].[cg_meta_area]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_area_by_reftable_sel]
  (@ref_version_id int, @table_name nvarchar(255))
AS
BEGIN
  SET NOCOUNT ON

  IF @table_name IS NOT NULL AND LEN(@table_name) > 0
  BEGIN
	SELECT DISTINCT
		a.[ref_version_id] AS [VersionId],
		a.[area_name] AS [AreaName],
		a.[IdColumn] AS [Id],
		a.[description] AS [Description],
		o.[objct_name] AS [CgMetaObjectName],
		o.[IdColumn] AS [ObjectIdColumn]
	FROM [dbo].[cg_meta_area] (NOLOCK) AS a
	INNER JOIN [dbo].[cg_meta_area_to_objct] (NOLOCK) AS aobj ON [a].[ref_version_id] = [aobj].[ref_version_id] AND [a].[area_name] = [aobj].[ref_area_name]
	INNER JOIN [dbo].[cg_meta_objct] (NOLOCK) AS o ON [o].[ref_version_id] = [aobj].[ref_version_id] AND [o].[objct_name] = [aobj].[ref_objct_id]
	WHERE [a].[ref_version_id] = @ref_version_id AND [o].[ref_table_name] = @table_name
	ORDER BY [a].[area_name], [o].[objct_name];
  END
END
