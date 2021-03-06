SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_objct_area_constraints_ups]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_area_constraints_ups];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 10/10/2019
-- Revised date:
-- Description : Create or update an object
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_area_constraints_ups]
	(@ref_version_id int,
	@objct_name nvarchar(255),
	@extraction_logic_name nvarchar(255),
	@MappedConstraints [CgMetaConstraintTableType] READONLY,
	@ObjectIdColumn int=NULL,
	@ErrorCodeStep5ObjConstraints int OUTPUT)
AS
BEGIN
	SET NOCOUNT ON

	IF @objct_name IS NULL OR LEN(LTRIM(@objct_name)) = 0
	BEGIN
		SELECT @ErrorCodeStep5ObjConstraints = 401; -- Object name is missing
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
				1, --step 5
				0, --step 6
				0, --step 7
				@ObjectIdColumn,
				@ErrorCodeStep5ObjConstraints OUTPUT;

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep5ObjConstraints, 0) > 0
		BEGIN
			RETURN(-1);
		END
	END

	IF EXISTS (SELECT * FROM @MappedConstraints)
	BEGIN
		INSERT INTO [dbo].[cg_meta_constraint_to_area]
           ([ref_version_id]
           ,[ref_extraction_logic_name]
           ,[ref_objct_name]
           ,[conField]
           ,[conOption]
           ,[conValue]
           ,[InSQL]
           ,[ref_area_id]
           ,[priority])
		SELECT
			@ref_version_id
			, @extraction_logic_name
			, @objct_name
			, [constraintField]
			, [constraintOption]
			, [constraintValue]
			, [InSQL]
			, [area_name]
			, [priority]
		FROM @MappedConstraints
	END

END