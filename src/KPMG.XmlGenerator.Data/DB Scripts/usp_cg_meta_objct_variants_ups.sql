SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_objct_variants_ups]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_variants_ups];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 10/10/2019
-- Revised date:
-- Description : Create or update an object
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_variants_ups]
	(@ref_version_id int,
	@objct_name nvarchar(255),
	@extraction_logic_name nvarchar(255),
	@MappedVariantIds nvarchar(MAX), --comma delimited list of Variant IDs
	@ObjectIdColumn int=NULL,
	@ErrorCodeStep7ObjVariants int OUTPUT)
AS
BEGIN
	SET NOCOUNT ON

	IF @objct_name IS NULL OR LEN(LTRIM(@objct_name)) = 0
	BEGIN
		SELECT @ErrorCodeStep7ObjVariants = 401; -- Object name is missing
		RETURN(-1);
	END

	IF @ObjectIdColumn IS NOT NULL
	BEGIN
		DECLARE @RetVal int;

		EXEC @RetVal = [dbo].[usp_cg_meta_objct_del]
				@ref_version_id,
				@objct_name,
				0, --step 1
				0, --step 2
				0, --step 3
				0, --step 4
				0, --step 5
				0, --step 6
				1, --step 7
				@ObjectIdColumn,
				@ErrorCodeStep7ObjVariants OUTPUT;

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep7ObjVariants, 0) > 0
		BEGIN
			RETURN(-1);
		END
	END

	IF @MappedVariantIds IS NOT NULL AND LEN(LTRIM(@MappedVariantIds)) > 0
	BEGIN
		SET @MappedVariantIds = N',' + @MappedVariantIds + ',';

		INSERT INTO [dbo].[cg_meta_variant_objct]
           ([ref_version_id]
           ,[ref_variant_name]
           ,[ref_objct_name]
           ,[ref_extraction_logic_name])
		SELECT
			@ref_version_id
			, [variant_name]
			, @objct_name
			, @extraction_logic_name
		FROM [dbo].[cg_meta_variant]
		WHERE CHARINDEX(',' + CAST([IdColumn] AS varchar(30)) + ',', @MappedVariantIds) > 0
	END
END