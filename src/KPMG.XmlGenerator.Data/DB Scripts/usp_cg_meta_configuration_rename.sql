SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_configuration_rename]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_configuration_rename];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 03/09/2019
-- Revised date: 10/09/2019
-- Description : Rename
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_configuration_rename]
  (@ref_version_id int,@configuration_name nvarchar(255),@ref_variant_name nvarchar(255),@IdColumn int=NULL,@NewIdColumn int OUTPUT, @ErrorCode int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON
  SET XACT_ABORT ON
  BEGIN TRAN
	
	 IF @IdColumn is NOT NULL
	 BEGIN
		 DECLARE @ExistingConfigurationName nvarchar(255)
		 SELECT @ref_version_id = [ref_version_id], @ExistingConfigurationName = [configuration_name] FROM [dbo].[cg_meta_variant_config] WHERE [IdColumn] = @IdColumn;
		 
		 IF @configuration_name IS NOT NULL AND LEN(LTRIM(RTRIM(@configuration_name))) > 0
		 BEGIN

			 UPDATE cg_meta_variant_config
			 SET configuration_name = @configuration_name
			 WHERE ref_version_id = @ref_version_id
			 AND configuration_name = @ExistingConfigurationName
			 
		 END
		 ELSE
			SELECT @ErrorCode = 301; --Configuration name is missing

	 END
	 ELSE 
		SELECT @ErrorCode = 303; --No configuration was selected to rename

	COMMIT
END
