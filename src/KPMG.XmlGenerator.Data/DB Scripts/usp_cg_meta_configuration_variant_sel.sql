SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_configuration_variant_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_configuration_variant_sel];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 17/09/2019
-- Revised date:
-- Description : Select from [dbo].[cg_meta_variant_config]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_configuration_variant_sel]
  (@IdColumn int=NULL, @ref_version_id int = NULL)
AS
BEGIN
  SET NOCOUNT ON

  IF @IdColumn IS NOT NULL
  BEGIN
	  WITH [maps] AS
	  (SELECT
		vc.[ref_version_id],
		vc.[configuration_name],
		@IdColumn AS [ConfigurationIdColumn],
		v.[IdColumn] AS [VariantIdColumn]
	   FROM [dbo].[cg_meta_variant_config] AS vc
	   LEFT JOIN [dbo].[cg_meta_variant_config] AS vc1 ON vc1.[ref_version_id] = vc.[ref_version_id] AND vc1.[configuration_name] = vc.[configuration_name]
	   INNER JOIN [dbo].[cg_meta_variant] AS v ON v.[variant_name] = vc1.[ref_variant_name] AND v.[ref_version_id] = vc1.[ref_version_id]
	   WHERE vc.[IdColumn] = @IdColumn)
	  SELECT
		a.[ref_version_id],
		a.[configuration_name],
		a.[ConfigurationIdColumn],
		[MapMetaVariantIdColumns] = STUFF((SELECT ',' + CAST(b.[VariantIdColumn] AS VARCHAR(30)) FROM [maps] AS b WHERE b.[ConfigurationIdColumn] = a.[ConfigurationIdColumn] AND b.[ref_version_id] = a.[ref_version_id] FOR XML PATH('')), 1, 1, '')
	   FROM [maps] AS a
	   GROUP BY a.[ref_version_id], a.[configuration_name], a.[ConfigurationIdColumn];
  END
  ELSE
  BEGIN
	  WITH [maps] AS
	  (SELECT
		vc.[ref_version_id],
		vc.[configuration_name],
		vc.[IdColumn] AS [ConfigurationIdColumn],
		v.[IdColumn] AS [VariantIdColumn]
	   FROM [dbo].[cg_meta_variant_config] AS vc
	   LEFT JOIN [dbo].[cg_meta_variant] AS v ON v.[variant_name] = vc.[ref_variant_name] AND v.[ref_version_id] = vc.[ref_version_id]
	   WHERE vc.[ref_version_id] = CASE WHEN @ref_version_id IS NULL THEN vc.[ref_version_id] ELSE @ref_version_id END)
	  SELECT
		a.[ref_version_id],
		a.[configuration_name],
		MAX(a.[ConfigurationIdColumn]) AS [ConfigurationIdColumn],
		[MapMetaVariantIdColumns] = STUFF((SELECT ',' + CAST(b.[VariantIdColumn] AS VARCHAR(30)) FROM [maps] AS b WHERE b.[configuration_name] = a.[configuration_name] AND b.[ref_version_id] = a.[ref_version_id] FOR XML PATH('')), 1, 1, '')
	   FROM [maps] AS a
	   GROUP BY a.[ref_version_id], a.[configuration_name];
  END
END