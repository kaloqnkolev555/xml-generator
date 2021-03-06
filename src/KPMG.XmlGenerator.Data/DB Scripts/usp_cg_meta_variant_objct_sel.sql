/****** Object:  StoredProcedure [dbo].[usp_cg_meta_variant_objct_sel]    Script Date: 12.9.2019 г. 15:44:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_variant_objct_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_variant_objct_sel];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 12/09/2019
-- Revised date: 
-- Description : Select from [dbo].[cg_meta_variant_objct]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_variant_objct_sel]
  (@IdColumn int = NULL, @ref_version_id int = NULL)
AS
BEGIN
  SET NOCOUNT ON;

  -- @IdColumn is treated as variant IdColumn
  IF @IdColumn IS NOT NULL
  BEGIN
	  WITH [maps] AS
	  (SELECT
		v2o.[ref_version_id],
		v2o.[ref_variant_name],
		v.[IdColumn] AS [VariantIdColumn],
		o.[IdColumn] AS [ObjctIdColumn]
	   FROM [dbo].[cg_meta_variant_objct] AS v2o
	   INNER JOIN [dbo].[cg_meta_variant] AS v ON v.[variant_name] = v2o.[ref_variant_name] AND v.[ref_version_id] = v2o.[ref_version_id]
	   INNER JOIN [dbo].[cg_meta_objct] AS o ON o.[objct_name] = v2o.[ref_objct_name] AND o.[ref_version_id] = v2o.[ref_version_id]
	   WHERE v.[IdColumn] = @IdColumn)
	  SELECT
		a.[ref_version_id],
		a.[ref_variant_name] AS [variant_name],
		a.[VariantIdColumn],
		[MapMetaObjctIdColumns] = STUFF((SELECT ',' + CAST(b.[ObjctIdColumn] AS VARCHAR(30)) FROM [maps] AS b WHERE b.[ref_variant_name] = a.[ref_variant_name] AND b.[ref_version_id] = a.[ref_version_id] FOR XML PATH('')), 1, 1, '')
	   FROM [maps] AS a
	   GROUP BY a.[ref_version_id], a.[ref_variant_name], a.[VariantIdColumn];
  END
  ELSE
  BEGIN
	  WITH [maps] AS
	  (SELECT
		v2o.[ref_version_id],
		v2o.[ref_variant_name],
		v.[IdColumn] AS [VariantIdColumn],
		o.[IdColumn] AS [ObjctIdColumn]
	   FROM [dbo].[cg_meta_variant_objct] AS v2o
	   INNER JOIN [dbo].[cg_meta_variant] AS v ON v.[variant_name] = v2o.[ref_variant_name] AND v.[ref_version_id] = v2o.[ref_version_id]
	   INNER JOIN [dbo].[cg_meta_objct] AS o ON o.[objct_name] = v2o.[ref_objct_name] AND o.[ref_version_id] = v2o.[ref_version_id]
	   WHERE v2o.[ref_version_id] = CASE WHEN @ref_version_id IS NULL THEN v2o.[ref_version_id] ELSE @ref_version_id END)
	  SELECT
		a.[ref_version_id],
		a.[ref_variant_name] AS [variant_name],
		a.[VariantIdColumn],
		[MapMetaObjctIdColumns] = STUFF((SELECT ',' + CAST(b.[ObjctIdColumn] AS VARCHAR(30)) FROM [maps] AS b WHERE b.[ref_variant_name] = a.[ref_variant_name] AND b.[ref_version_id] = a.[ref_version_id] FOR XML PATH('')), 1, 1, '')
	   FROM [maps] AS a
	   GROUP BY a.[ref_version_id], a.[ref_variant_name], a.[VariantIdColumn];
  END

END
GO
