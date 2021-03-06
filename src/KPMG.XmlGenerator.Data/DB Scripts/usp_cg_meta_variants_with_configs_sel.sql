SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_variants_with_configs_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_variants_with_configs_sel];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 03/10/2019
-- Revised date: 
-- Description : Select all records from [dbo].[cg_meta_variant] with corresponding records in [dbo].[cg_meta_variant_config]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_variants_with_configs_sel]
  (@IdColumn int = NULL, @ref_version_id int = NULL)
AS
BEGIN
  SET NOCOUNT ON

  IF @IdColumn IS NULL
  BEGIN
      SELECT variant.[ref_version_id] AS VersionId, variant.[variant_name] AS VariantName, variant.[IdColumn] AS Id,
	         variant.[description] AS [Description], config.[configuration_name] AS ConfigurationName, config.[ref_variant_name] AS VariantName,
             config.[ref_version_id] AS VersionId, config.[IdColumn] AS Id
	    FROM [dbo].[cg_meta_variant] variant
	    LEFT OUTER JOIN [dbo].[cg_meta_variant_config] config
	    ON variant.[ref_version_id] = config.[ref_version_id] AND
	       variant.[variant_name] = config.[ref_variant_name]
	    WHERE variant.[ref_version_id] = 
		    CASE 
			    WHEN @ref_version_id IS NULL THEN variant.[ref_version_id] 
			    ELSE @ref_version_id 
		    END 
        ORDER BY variant.[variant_name]
  END
  ELSE
  BEGIN
    SELECT variant.[ref_version_id] AS VersionId, variant.[variant_name] AS VariantName, variant.[IdColumn] AS Id,
	       variant.[description] AS [Description], config.[configuration_name] AS ConfigurationName, config.[ref_variant_name] AS VariantName,
           config.[ref_version_id] AS VersionId, config.[IdColumn] AS Id
	    FROM [dbo].[cg_meta_variant] variant
	    LEFT OUTER JOIN [dbo].[cg_meta_variant_config] config
	    ON variant.[ref_version_id] = config.[ref_version_id] AND
	       variant.[variant_name] = config.[ref_variant_name]
	    WHERE variant.[IdColumn] = @IdColumn 
	    ORDER BY variant.[variant_name]
  END

END
