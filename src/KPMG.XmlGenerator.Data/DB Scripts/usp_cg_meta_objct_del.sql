SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_objct_del]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_del];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 10/09/2019
-- Revised date:
-- Description : Delete
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_del]
  (@ref_version_id int,
  @objct_name nvarchar(255),
  @DeleteStep1 bit,
  @DeleteStep2 bit,
  @DeleteStep3 bit,
  @DeleteStep4 bit,
  @DeleteStep5 bit,
  @DeleteStep6 bit,
  @DeleteStep7 bit,
  @IdColumn int,
  @ErrorCode int OUTPUT)
AS
BEGIN
	SET NOCOUNT ON
	SET XACT_ABORT ON

	IF @IdColumn IS NULL
	BEGIN
		SET @ErrorCode = 402; -- No object to delete
		RETURN(-1);
	END

	IF ISNULL(@objct_name, '') = ''
	BEGIN
		SELECT @objct_name = [objct_name] from [dbo].[cg_meta_objct] WHERE [IdColumn] = @IdColumn
	END

	DECLARE @isFooter bit
	SELECT @isFooter = is_footer from [dbo].[cg_meta_objct] where [ref_version_id] = @ref_version_id and [IdColumn] = @IdColumn

	BEGIN TRAN

	-- Step 7: remove object from variant mapping
	IF @DeleteStep7 = 1 AND EXISTS (SELECT 1 FROM  [dbo].[cg_meta_variant_objct] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @objct_name)
	BEGIN
		DELETE FROM [dbo].[cg_meta_variant_objct] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @objct_name
	END

	-- Step 6: remove object from hard constraints mapping
	IF @DeleteStep6 = 1 AND EXISTS (SELECT 1 FROM [dbo].[cg_meta_hconstraint_to_area] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @objct_name)
	BEGIN
		DELETE FROM [dbo].[cg_meta_hconstraint_to_area] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @objct_name
	END

    -- Step 5: remove object from constraints mapping
	IF @DeleteStep5 = 1 AND EXISTS (SELECT 1 FROM [dbo].[cg_meta_constraint_to_area] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @objct_name)
	BEGIN
		DELETE FROM [dbo].[cg_meta_constraint_to_area] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @objct_name
	END

	-- Step 4: remove object-column mappings
	IF @DeleteStep4 = 1 AND EXISTS (SELECT 1 FROM [dbo].[cg_meta_column] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @objct_name)
	BEGIN
		DELETE FROM [dbo].[cg_meta_column] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @objct_name
	END

	-- Step 3: remove object-area mappings
	IF @DeleteStep3 = 1 AND EXISTS (SELECT 1 FROM [dbo].[cg_meta_area_to_objct] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_id] = @objct_name)
	BEGIN
		DELETE FROM [dbo].[cg_meta_area_to_objct] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_id] = @objct_name
	END

	-- Step 2: remove technical settings for object
	IF @DeleteStep2 = 1 AND EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @objct_name)
	BEGIN
		DELETE FROM [dbo].[cg_meta_technical_setting] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @objct_name
	END

	-- Step 1: remove original object
	IF @DeleteStep1 = 1
	BEGIN
		IF @isFooter = 1
		BEGIN
			DELETE FROM [dbo].[cg_meta_header_footer] where [ref_version_id] = @ref_version_id AND [ref_table_name] = @objct_name
		END

		DELETE FROM [dbo].[cg_meta_objct] WHERE [IdColumn] = @IdColumn
	END

	COMMIT
END
