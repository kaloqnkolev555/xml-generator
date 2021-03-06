SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_variant_find]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_variant_find];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 10/09/2019
-- Revised date: 
-- Description : Find variant by version and name 
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_variant_find]
  (@version_id int, @variant_name nvarchar(255), @IdColumn int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON;
  SELECT @IdColumn = [IdColumn] FROM [dbo].[cg_meta_variant] WHERE [ref_version_id] = @version_id AND [variant_name] = @variant_name;
END