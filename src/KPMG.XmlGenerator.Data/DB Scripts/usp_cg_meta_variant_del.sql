SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_variant_del]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_variant_del];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 02/09/2019
-- Revised date: 11/09/2019
-- Description : Delete 
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_variant_del]
  (@IdColumn nvarchar(max), @ErrorCode int OUTPUT)
AS
BEGIN
  IF @IdColumn IS NULL OR LEN(@IdColumn) < 1 
  BEGIN
    SET @ErrorCode = 202; -- No variant(s) to delete
    RETURN;
  END

  SET NOCOUNT ON
  SET XACT_ABORT ON
  BEGIN TRAN

  SET @IdColumn = ','+@IdColumn+',';
 
  DELETE c FROM cg_meta_variant_objct AS c
  INNER JOIN [dbo].[cg_meta_variant] AS v ON c.[ref_version_id] = v.[ref_version_id] AND c.[ref_variant_name] = v.[variant_name]
  WHERE CHARINDEX(','+cast(v.IdColumn as varchar(100))+',', @IdColumn) > 0;

  DELETE c FROM cg_meta_variant_config AS c
  INNER JOIN [dbo].[cg_meta_variant] AS v ON c.[ref_version_id] = v.[ref_version_id] AND c.[ref_variant_name] = v.[variant_name]
  WHERE CHARINDEX(','+cast(v.IdColumn as varchar(100))+',', @IdColumn) > 0;

  DELETE [dbo].[cg_meta_variant] 
  WHERE CHARINDEX(','+cast(IdColumn as varchar(100))+',', @IdColumn) > 0;
  
  SELECT @@ROWCOUNT as [Rows Affected];

  COMMIT

END
