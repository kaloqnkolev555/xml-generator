SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_objct_areas_ups]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_areas_ups];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 09/10/2019
-- Revised date:
-- Description : Create or update an object
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_areas_ups]
	(@ref_version_id int,
	@objct_name nvarchar(255),
	@MappedAreaIds nvarchar(MAX), --comma delimited list of Area IDs
	@ObjectIdColumn int=NULL,
	@ErrorCodeStep3ObjAreas int OUTPUT)
AS
BEGIN
	SET NOCOUNT ON

	IF @objct_name IS NULL OR LEN(LTRIM(@objct_name)) = 0
	BEGIN
		SELECT @ErrorCodeStep3ObjAreas = 401; -- Object name is missing
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
				1, --step 3
				1, --step 4
				1, --step 5
				1, --step 6
				1, --step 7
				@ObjectIdColumn,
				@ErrorCodeStep3ObjAreas OUTPUT;

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep3ObjAreas, 0) > 0
		BEGIN
			RETURN(-1);
		END
	END

	IF @MappedAreaIds IS NOT NULL AND LEN(LTRIM(@MappedAreaIds)) > 0
	BEGIN
		SET @MappedAreaIds = N',' + @MappedAreaIds + ',';

		INSERT INTO [dbo].[cg_meta_area_to_objct]
			   ([ref_version_id]
			   ,[ref_objct_id]
			   ,[ref_area_name])
		SELECT
			@ref_version_id
			,@objct_name
			,[area_name]
		FROM [dbo].[cg_meta_area]
		WHERE CHARINDEX(',' + CAST([IdColumn] AS varchar(30)) + ',', @MappedAreaIds) > 0
	END
END