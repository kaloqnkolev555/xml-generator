SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_objct_master_ups]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_master_ups];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 07/10/2019
-- Revised date:
-- Description : Create or update an object
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_master_ups]
	(@ref_version_id int,
	@objct_name nvarchar(255),
	@ref_group_name nvarchar(255),
	@ref_table_name nvarchar(255),
	@is_footer bit,
	@Description nvarchar(1000)=NULL,
	@is_default varchar(20)=NULL,
	@header_obct_name nvarchar(255) = NULL,
	@footerFileName nvarchar(255),
	@footerHashTotalField nvarchar(255),
	@ObjectIdColumn int=NULL,
	@extraction_logic_name nvarchar(255),
	@helperTable_name nvarchar(255) = NULL,
	@dayByDay nvarchar(255) = NULL,
	@daysPerLoop int = NULL,
	@nrobjct nvarchar(255) = NULL,
	@nrfield nvarchar(255) = NULL,
	@nrMin bit = NULL,
	@nrMax bit = NULL,
	@parallel int = NULL,
	@pkgSize int = NULL,
	@pkgSize2 int = NULL,
	@xFilename nvarchar(255) = NULL,
	@hashtotalField nvarchar(255) = NULL,
	@ts_is_default bit = NULL,
	@docNbr nvarchar(50) = NULL,
	@loopAt nvarchar(50) = NULL,
	@MappedAreaIds nvarchar(MAX) = NULL,
	@MappedColumns [CgMetaColumnTableType] READONLY,
	@MappedConstraints [CgMetaConstraintTableType] READONLY,
    @MappedHConstraints [CgMetaHConstraintTableType] READONLY,
	@MappedVariantIds nvarchar(MAX) = NULL,
	@Step1CgMetaObjChanged bit=NULL,
	@Step2ObjTechSettingsChanged bit=NULL,
	@Step3ObjAreasChanged bit=NULL,
	@Step4ObjAreasColumnsChanged bit=NULL,
	@Step5ObjConstraintsChanged bit=NULL,
	@Step6ObjHardConstraintsChanged bit=NULL,
	@Step7ObjVariantsChanged bit=NULL,
	@NewObjctIdColumn int OUTPUT,
	@ErrorCode int OUTPUT)
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	DECLARE @NewTSIdColumn int;

	DECLARE @ErrorCodeStep1CgMetaObj int;
	DECLARE @ErrorCodeStep2ObjTechnicalSettings int;
	DECLARE @ErrorCodeStep3ObjAreas int;
	DECLARE @ErrorCodeStep4ObjAreasColumns int;
	DECLARE @ErrorCodeStep5ObjConstraints int;
	DECLARE @ErrorCodeStep6ObjHConstraints int;
	DECLARE @ErrorCodeStep7ObjVariants int;
	DECLARE @RetVal int;

	BEGIN TRAN

	BEGIN TRY

	IF @Step1CgMetaObjChanged IS NULL OR @Step1CgMetaObjChanged = 1
	BEGIN
		EXEC @RetVal = [dbo].[usp_cg_meta_objct_ups] @ref_version_id,
			@objct_name,
			@ref_group_name,
			@ref_table_name,
			@is_footer,
			@Description,
			@is_default,
			@header_obct_name,
			@footerFileName,
			@footerHashTotalField,
			@ObjectIdColumn,
			@NewObjctIdColumn OUTPUT,
			@ErrorCodeStep1CgMetaObj OUTPUT;

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep1CgMetaObj, 0) > 0
		BEGIN
			SET @ErrorCode = @ErrorCodeStep1CgMetaObj;
			RAISERROR(N'Call to step 1 failed (error code: %d)', 16, 1, @ErrorCode);
		END
	END

	IF @Step2ObjTechSettingsChanged IS NULL OR @Step2ObjTechSettingsChanged = 1
	BEGIN
		EXEC @RetVal = [dbo].[usp_cg_meta_objct_technical_settings_ups]
			@ref_version_id,
			@objct_name,
			@extraction_logic_name,
			@helperTable_name,
			@dayByDay,
			@daysPerLoop,
			@nrobjct ,
			@nrfield ,
			@nrMin,
			@nrMax,
			@parallel,
			@pkgSize,
			@pkgSize2,
			@xFilename,
			@hashtotalField,
			@ts_is_default,
			@docNbr,
			@loopAt,
			@ObjectIdColumn,
			@NewTSIdColumn OUTPUT,
			@ErrorCodeStep2ObjTechnicalSettings OUTPUT

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep2ObjTechnicalSettings, 0) > 0
		BEGIN
			SET @ErrorCode = @ErrorCodeStep2ObjTechnicalSettings;
            RAISERROR(N'Call to step 2 failed (error code: %d)', 16, 1, @ErrorCode);
		END
	END

	IF @Step3ObjAreasChanged IS NULL OR @Step3ObjAreasChanged = 1
	BEGIN
		EXEC @RetVal = [dbo].[usp_cg_meta_objct_areas_ups]
			@ref_version_id,
			@objct_name,
			@MappedAreaIds,
			@ObjectIdColumn,
			@ErrorCodeStep3ObjAreas OUTPUT

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep3ObjAreas, 0) > 0
		BEGIN
			SET @ErrorCode = @ErrorCodeStep3ObjAreas;
            RAISERROR(N'Call to step 3 failed (error code: %d)', 16, 1, @ErrorCode);
		END
	END

	IF @Step4ObjAreasColumnsChanged IS NULL OR @Step4ObjAreasColumnsChanged = 1
	BEGIN
		EXEC @RetVal = [dbo].[usp_cg_meta_objct_area_columns_ups]
			@ref_version_id,
			@objct_name,
			@MappedColumns,
			@ObjectIdColumn,
			@ErrorCodeStep4ObjAreasColumns OUTPUT

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep4ObjAreasColumns, 0) > 0
		BEGIN
			SET @ErrorCode = @ErrorCodeStep4ObjAreasColumns;
            RAISERROR(N'Call to step 4 failed (error code: %d)', 16, 1, @ErrorCode);
		END
	END

	IF @Step5ObjConstraintsChanged IS NULL OR @Step5ObjConstraintsChanged = 1
	BEGIN
		EXEC @RetVal = [dbo].[usp_cg_meta_objct_area_constraints_ups]
			@ref_version_id,
			@objct_name,
			@extraction_logic_name,
			@MappedConstraints,
			@ObjectIdColumn,
			@ErrorCodeStep5ObjConstraints OUTPUT

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep5ObjConstraints, 0) > 0
		BEGIN
			SET @ErrorCode = @ErrorCodeStep5ObjConstraints;
            RAISERROR(N'Call to step 5 failed (error code: %d)', 16, 1, @ErrorCode);
		END
	END

	IF @Step6ObjHardConstraintsChanged IS NULL OR @Step6ObjHardConstraintsChanged = 1
	BEGIN
		EXEC @RetVal = [dbo].[usp_cg_meta_objct_area_hconstraints_ups]
			@ref_version_id,
			@objct_name,
			@extraction_logic_name,
			@MappedHConstraints,
			@ObjectIdColumn,
			@ErrorCodeStep6ObjHConstraints OUTPUT

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep6ObjHConstraints, 0) > 0
		BEGIN
			SET @ErrorCode = @ErrorCodeStep6ObjHConstraints;
            RAISERROR(N'Call to step 6 failed (error code: %d)', 16, 1, @ErrorCode);
		END
	END

	IF @Step7ObjVariantsChanged IS NULL OR @Step7ObjVariantsChanged = 1
	BEGIN
		EXEC @RetVal = [dbo].[usp_cg_meta_objct_variants_ups]
			@ref_version_id,
			@objct_name,
			@extraction_logic_name,
			@MappedVariantIds,
			@ObjectIdColumn,
			@ErrorCodeStep7ObjVariants OUTPUT

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep7ObjVariants, 0) > 0
		BEGIN
			SET @ErrorCode = @ErrorCodeStep7ObjVariants;
            RAISERROR(N'Call to step 7 failed (error code: %d)', 16, 1, @ErrorCode);
		END
	END
	END TRY
	BEGIN  CATCH
	    DECLARE @ErrorMessage NVARCHAR(MAX);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT
			@ErrorMessage=ERROR_MESSAGE(),
			@ErrorSeverity=ERROR_SEVERITY(),
			@ErrorState=ERROR_STATE();

		IF @@TRANCOUNT > 0
			ROLLBACK TRANSACTION;

        RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH

  IF @@TRANCOUNT > 0
  BEGIN
	COMMIT
	RETURN(0)
  END
END