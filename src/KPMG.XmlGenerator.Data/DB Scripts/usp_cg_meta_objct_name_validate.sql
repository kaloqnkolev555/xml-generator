SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- drop SP if it exists
IF OBJECT_ID('[dbo].[usp_cg_meta_objct_name_validate]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_name_validate];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 03/09/2019
-- Revised date:
-- Description : Validate unique [objct_name] for [dbo].[cg_meta_objct]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_name_validate]
  (@IdColumn int=NULL, @ref_version_id int, @objct_name nvarchar(255), @objct_name_taken bit OUTPUT)
AS
BEGIN
  SET NOCOUNT ON;

  DECLARE @FoundIdColumn int;
  SELECT @FoundIdColumn = [IdColumn] FROM [dbo].[cg_meta_objct] WHERE [ref_version_id] = @ref_version_id AND [objct_name] = @objct_name;

  SET @objct_name_taken = CAST(CASE WHEN @FoundIdColumn IS NOT NULL AND (@IdColumn IS NULL OR @IdColumn != @FoundIdColumn) THEN 1 ELSE 0 END AS BIT);

END