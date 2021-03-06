SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_area_rename]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_area_rename];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 03/09/2019
-- Revised date: 09/09/2019
-- Description : Rename
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_area_rename]
  (@ref_version_id int,@area_name nvarchar(255),@description nvarchar(200)=NULL,@IdColumn int=NULL,@NewIdColumn int OUTPUT, @ErrorCode int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON
  SET XACT_ABORT ON
  BEGIN TRAN
	
	 IF @IdColumn is NOT NULL
	 BEGIN
		 DECLARE @ExistingAreaName NVARCHAR(255)
		 SELECT @ref_version_id = [ref_version_id], @ExistingAreaName = [area_name] FROM [dbo].[cg_meta_area] WHERE [IdColumn] = @IdColumn;
		 
		 IF @area_name IS NOT NULL AND LEN(LTRIM(RTRIM(@area_name))) > 0
		 BEGIN

			 INSERT INTO [dbo].[cg_meta_area]
				([ref_version_id],[area_name],[description])
			 VALUES
				(@ref_version_id, @area_name, @description);

			 SELECT @NewIdColumn = SCOPE_IDENTITY();

			 UPDATE cg_meta_column
			 SET ref_area_name = @area_name
			 WHERE ref_version_id = @ref_version_id
			 AND ref_area_name = @ExistingAreaName

			 UPDATE cg_meta_area_to_objct
			 SET ref_area_name = @area_name
			 WHERE ref_version_id = @ref_version_id
			 AND ref_area_name = @ExistingAreaName

			 UPDATE cg_meta_constraint_to_area
			 SET ref_area_id = @area_name
			 WHERE ref_version_id = @ref_version_id
			 AND ref_area_id = @ExistingAreaName

			 UPDATE cg_meta_hconstraint_to_area
			 SET ref_area_id = @area_name
			 WHERE ref_version_id = @ref_version_id
			 AND ref_area_id = @ExistingAreaName
	 
			 UPDATE cg_meta_scope
			 SET ref_area_name = @area_name
			 WHERE ref_version_id = @ref_version_id
			 AND ref_area_name = @ExistingAreaName

			 DELETE FROM [cg_meta_area] WHERE [IdColumn]= @IdColumn;
		END
		ELSE
			SELECT @ErrorCode = 101; -- Area name is missing

	 END
	 ELSE 
		SELECT @ErrorCode = 103; -- No area was selected to rename

	COMMIT
END
