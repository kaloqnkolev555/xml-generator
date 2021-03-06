SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_configuration_del]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_configuration_del];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 02/09/2019
-- Revised date: 10/09/2019
-- Description : Delete 
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_configuration_del]
  (@IdColumn nvarchar(max), @ErrorCode int OUTPUT)
AS
BEGIN
  IF @IdColumn IS NULL OR LEN(@IdColumn) < 1 
  BEGIN
    SET @ErrorCode = 302; -- No configuration(s) to delete
    RETURN;
  END

  SET NOCOUNT ON
  SET XACT_ABORT ON
  BEGIN TRAN

  SET @IdColumn = ','+@IdColumn+',';
 
  WITH [distinct_mvc] AS
  (
    SELECT [ref_version_id], [configuration_name]
    FROM [dbo].[cg_meta_variant_config]
    WHERE CHARINDEX(','+cast(IdColumn as varchar(30))+',', @IdColumn) > 0
  )
  DELETE [dbo].[cg_meta_variant_config]
	WHERE [ref_version_id] IN (SELECT [ref_version_id] FROM [distinct_mvc]) AND [configuration_name] IN (SELECT [configuration_name] FROM [distinct_mvc]);

  SELECT @@ROWCOUNT as [Rows Affected];

  COMMIT

END
