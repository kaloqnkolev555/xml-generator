SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_variant_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_variant_sel];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 05/09/2019
-- Revised date: 
-- Description : Select from [dbo].[cg_meta_variant]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_variant_sel]
  (@IdColumn int=NULL, @ref_version_id int = NULL)
AS
BEGIN
  SET NOCOUNT ON

  IF @IdColumn IS NULL
    SELECT * FROM [dbo].[cg_meta_variant] WHERE [ref_version_id] = CASE WHEN @ref_version_id IS NULL THEN [ref_version_id] ELSE @ref_version_id END ORDER BY [variant_name];
  ELSE
    SELECT * FROM [dbo].[cg_meta_variant] WHERE [IdColumn] = @IdColumn;

END