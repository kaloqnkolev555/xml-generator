SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_variant_rename]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_variant_rename];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 03/09/2019
-- Revised date: 10/09/2019
-- Description : Rename
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_variant_rename]
  (@ref_version_id int,@variant_name nvarchar(255),@description nvarchar(200)=NULL,@IdColumn int=NULL,@NewIdColumn int OUTPUT, @ErrorCode int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON
  SET XACT_ABORT ON
  BEGIN TRAN
	
	 IF @IdColumn is NOT NULL
	 BEGIN
		 DECLARE @ExistingVariantName nvarchar(255)
		 SELECT @ref_version_id = [ref_version_id], @ExistingVariantName = [variant_name] FROM [dbo].[cg_meta_variant] WHERE [IdColumn] = @IdColumn;
		 
		 IF @variant_name IS NOT NULL AND LEN(LTRIM(RTRIM(@variant_name))) > 0
		 BEGIN

			 INSERT INTO [dbo].[cg_meta_variant]
				([ref_version_id],[variant_name],[description])
			 VALUES
				(@ref_version_id, @variant_name, @description);

			 SELECT @NewIdColumn = SCOPE_IDENTITY();

			 UPDATE cg_meta_variant_objct
			 SET ref_variant_name = @variant_name
			 WHERE ref_version_id = @ref_version_id
			 AND ref_variant_name = @ExistingVariantName

			 UPDATE cg_meta_variant_config
			 SET ref_variant_name = @variant_name
			 WHERE ref_version_id = @ref_version_id
			 AND ref_variant_name = @ExistingVariantName

			 DELETE FROM [cg_meta_variant] WHERE [IdColumn]= @IdColumn;
			 
		END
		ELSE
			SELECT @ErrorCode = 201; -- Variant name is missing

	 END
	 ELSE 
		SELECT @ErrorCode = 203; -- No variant was selected to rename

	COMMIT
END
