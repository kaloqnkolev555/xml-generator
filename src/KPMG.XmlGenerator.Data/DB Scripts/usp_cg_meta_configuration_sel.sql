SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_configuration_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_configuration_sel];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 16/09/2019
-- Revised date: 
-- Description : Select from [dbo].[cg_meta_variant_config]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_configuration_sel]
  (@IdColumn int=NULL, @ref_version_id int = NULL)
AS
BEGIN
  SET NOCOUNT ON

  IF @IdColumn IS NULL
    SELECT
	  MAX([ref_version_id]) AS [ref_version_id],
	  [configuration_name],
	  N'' AS [ref_variant_name],
	  MAX(IdColumn) AS [IdColumn]
	  FROM [dbo].[cg_meta_variant_config] 
	  WHERE [ref_version_id] = CASE WHEN @ref_version_id IS NULL THEN [ref_version_id] ELSE @ref_version_id END 
	  GROUP BY [configuration_name]	
	  ORDER BY [configuration_name];
  ELSE
    SELECT * FROM [dbo].[cg_meta_variant_config] WHERE [IdColumn] = @IdColumn;

END