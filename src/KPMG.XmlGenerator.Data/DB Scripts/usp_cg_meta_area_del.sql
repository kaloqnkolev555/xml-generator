SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_area_del]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_area_del];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 02/09/2019
-- Revised date: 10/09/2019
-- Description : Delete one or more areas
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_area_del]
  (@IdColumn nvarchar(max), @ErrorCode int OUTPUT)
AS
BEGIN
  IF @IdColumn IS NULL OR LEN(@IdColumn) < 1 
  BEGIN
    SET @ErrorCode = 102; -- No area(s) to delete
    RETURN;
  END

  SET NOCOUNT ON
  SET XACT_ABORT ON
  BEGIN TRAN

  SET @IdColumn = ','+@IdColumn+',';
 
  DELETE c FROM cg_meta_column AS c
  INNER JOIN [dbo].[cg_meta_area] AS a ON c.[ref_version_id] = a.[ref_version_id] AND c.[ref_area_name] = a.[area_name]
  WHERE CHARINDEX(','+cast(a.IdColumn as varchar(30))+',', @IdColumn) > 0

  DELETE c FROM cg_meta_area_to_objct AS c
  INNER JOIN [dbo].[cg_meta_area] AS a ON c.[ref_version_id] = a.[ref_version_id] AND c.[ref_area_name] = a.[area_name]
  WHERE CHARINDEX(','+cast(a.IdColumn as varchar(30))+',', @IdColumn) > 0;

  DELETE c FROM cg_meta_constraint_to_area AS c
  INNER JOIN [dbo].[cg_meta_area] AS a ON c.[ref_version_id] = a.[ref_version_id] AND c.[ref_area_id] = a.[area_name]
  WHERE CHARINDEX(','+cast(a.IdColumn as varchar(30))+',', @IdColumn) > 0

  DELETE c FROM cg_meta_hconstraint_to_area AS c
  INNER JOIN [dbo].[cg_meta_area] AS a ON c.[ref_version_id] = a.[ref_version_id] AND c.[ref_area_id] = a.[area_name]
  WHERE CHARINDEX(','+cast(a.IdColumn as varchar(30))+',', @IdColumn) > 0

  DELETE c FROM cg_meta_scope AS c
  INNER JOIN [dbo].[cg_meta_area] AS a ON c.[ref_version_id] = a.[ref_version_id] AND c.[ref_area_name] = a.[area_name]
  WHERE CHARINDEX(','+cast(a.IdColumn as varchar(30))+',', @IdColumn) > 0

  DELETE [dbo].[cg_meta_area]
  WHERE CHARINDEX(','+cast(IdColumn as varchar(30))+',', @IdColumn) > 0
  
  SELECT @@ROWCOUNT as [Rows Affected];

  COMMIT

END
