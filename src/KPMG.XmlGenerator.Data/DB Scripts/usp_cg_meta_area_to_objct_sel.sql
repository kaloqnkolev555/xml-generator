/****** Object:  StoredProcedure [dbo].[usp_cg_meta_area_to_objct_sel]    Script Date: 12.9.2019 г. 15:44:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_area_to_objct_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_area_to_objct_sel];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 12/09/2019
-- Revised date: 
-- Description : Select from [dbo].[cg_meta_area_to_objct]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_area_to_objct_sel]
  (@IdColumn int=NULL, @ref_version_id int = NULL)
AS
BEGIN
  SET NOCOUNT ON;

  -- @IdColumn is treated as area IdColumn
  IF @IdColumn IS NOT NULL
  BEGIN
	  WITH [maps] AS
	  (SELECT
		a2o.[ref_version_id],
		a2o.[ref_area_name],
		a.[IdColumn] AS [AreaIdColumn],
		o.[IdColumn] AS [ObjctIdColumn]
	   FROM [dbo].[cg_meta_area_to_objct] AS a2o
	   INNER JOIN [dbo].[cg_meta_area] AS a ON a.[area_name] = a2o.[ref_area_name] AND a.[ref_version_id] = a2o.[ref_version_id]
	   INNER JOIN [dbo].[cg_meta_objct] AS o ON o.[objct_name] = a2o.[ref_objct_id] AND o.[ref_version_id] = a2o.[ref_version_id]
	   WHERE a.[IdColumn] = @IdColumn)
	  SELECT
		a.[ref_version_id],
		a.[ref_area_name] AS [area_name],
		a.[AreaIdColumn],
		[MapMetaObjctIdColumns] = STUFF((SELECT ',' + CAST(b.[ObjctIdColumn] AS VARCHAR(30)) FROM [maps] AS b WHERE b.[ref_area_name] = a.[ref_area_name] AND b.[ref_version_id] = a.[ref_version_id] FOR XML PATH('')), 1, 1, '')
	   FROM [maps] AS a
	   GROUP BY a.[ref_version_id], a.[ref_area_name], a.[AreaIdColumn];
  END
  ELSE
  BEGIN
	  WITH [maps] AS
	  (SELECT
		a2o.[ref_version_id],
		a2o.[ref_area_name],
		a.[IdColumn] AS [AreaIdColumn],
		o.[IdColumn] AS [ObjctIdColumn]
	   FROM [dbo].[cg_meta_area_to_objct] AS a2o
	   INNER JOIN [dbo].[cg_meta_area] AS a ON a.[area_name] = a2o.[ref_area_name] AND a.[ref_version_id] = a2o.[ref_version_id]
	   INNER JOIN [dbo].[cg_meta_objct] AS o ON o.[objct_name] = a2o.[ref_objct_id] AND o.[ref_version_id] = a2o.[ref_version_id]
	   WHERE a2o.[ref_version_id] = CASE WHEN @ref_version_id IS NULL THEN a2o.[ref_version_id] ELSE @ref_version_id END)
	  SELECT
		a.[ref_version_id],
		a.[ref_area_name] AS [area_name],
		a.[AreaIdColumn],
		[MapMetaObjctIdColumns] = STUFF((SELECT ',' + CAST(b.[ObjctIdColumn] AS VARCHAR(30)) FROM [maps] AS b WHERE b.[ref_area_name] = a.[ref_area_name] AND b.[ref_version_id] = a.[ref_version_id] FOR XML PATH('')), 1, 1, '')
	   FROM [maps] AS a
	   GROUP BY a.[ref_version_id], a.[ref_area_name], a.[AreaIdColumn];
  END

END
GO
