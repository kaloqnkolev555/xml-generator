SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_objct_ups]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_ups];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 07/10/2019
-- Revised date:
-- Description : Create or update an object
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_ups]
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
	@IdColumn int=NULL,
	@NewObjctIdColumn int OUTPUT,
	@ErrorCodeStep1CgMetaObj int OUTPUT)
AS
BEGIN
	SET NOCOUNT ON

	IF @objct_name IS NULL OR LEN(LTRIM(@objct_name)) = 0
	BEGIN
		SELECT @ErrorCodeStep1CgMetaObj = 401; -- Object name is missing
		RETURN(-1);
	END

	IF @ref_table_name IS NULL OR LEN(LTRIM(@ref_table_name)) = 0
	BEGIN
		SELECT @ErrorCodeStep1CgMetaObj = 501; -- Table name is missing
		RETURN(-1);
	END

	IF @IdColumn IS NOT NULL
	BEGIN
		-- Check if this name already exists for this version
		IF EXISTS (SELECT 1 FROM [dbo].[cg_meta_objct] WHERE [ref_version_id] = @ref_version_id AND [objct_name] = @objct_name AND [IdColumn] <> @IdColumn)
		BEGIN
			SELECT @ErrorCodeStep1CgMetaObj = 405; -- Object name is not unique
			RETURN(-1);
		END

		DECLARE @currentObjctName nvarchar(255)

		SELECT @currentObjctName = [objct_name] FROM [dbo].[cg_meta_objct] WHERE [IdColumn] = @IdColumn;

		IF ISNULL(@currentObjctName, '') <> ''
		BEGIN
			DECLARE @RetVal int;

			EXEC @RetVal = [dbo].[usp_cg_meta_objct_del] @ref_version_id,
				@currentObjctName,
				1, --step 1
				1, --step 2
				1, --step 3
				1, --step 4
				1, --step 5
				1, --step 6
				1, --step 7
				@IdColumn,
				@ErrorCodeStep1CgMetaObj OUTPUT;

			IF @RetVal = -1 OR ISNULL(@ErrorCodeStep1CgMetaObj, 0) > 0
			BEGIN
				RETURN(-1);
			END
		END
	END
	ELSE
	BEGIN
		-- Check if this name already exists for this version
		IF EXISTS (SELECT 1 FROM [dbo].[cg_meta_objct] WHERE [ref_version_id] = @ref_version_id AND [objct_name] = @objct_name)
		BEGIN
			SELECT @ErrorCodeStep1CgMetaObj = 405; -- Object name is not unique
			RETURN(-1);
		END
	END

	INSERT INTO [dbo].[cg_meta_objct]
		([ref_version_id]
		,[objct_name]
		,[ref_group_name]
		,[ref_table_name]
		,[is_footer]
		,[Description]
		,[is_default])
	VALUES
		(@ref_version_id
		,@objct_name
		,ISNULL(@ref_group_name, '')
		,@ref_table_name
		,@is_footer
		,ISNULL(@Description, '')
		,@is_default)

	SELECT @NewObjctIdColumn = SCOPE_IDENTITY();

	IF @is_footer = 1 AND NOT EXISTS
		(SELECT 1 FROM [dbo].[cg_meta_header_footer] WHERE [ref_version_id] = @ref_version_id AND [ref_objct_name] = @header_obct_name AND [ref_table_name] = @ref_table_name AND [footer_fileName] = @footerFileName)
	BEGIN
		INSERT INTO [dbo].[cg_meta_header_footer]
			([ref_version_id]
			,[ref_objct_name]
			,[ref_table_name]
			,[footer_fileName]
			,[footer_hashtotalField])
		VALUES
			(@ref_version_id
			,@header_obct_name
			,@objct_name
			,@footerFileName
			,ISNULL(@footerHashTotalField, ''))
	END
END