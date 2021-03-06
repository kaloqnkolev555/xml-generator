SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_objct_area_columns_ups]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_area_columns_ups];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 09/10/2019
-- Revised date:
-- Description : Create or update an object
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_area_columns_ups]
	(@ref_version_id int,
	@objct_name nvarchar(255),
	@MappedColumns [CgMetaColumnTableType] READONLY,
	@ObjectIdColumn int=NULL,
	@ErrorCodeStep4ObjAreasColumns int OUTPUT)
AS
BEGIN
	SET NOCOUNT ON

	IF @objct_name IS NULL OR LEN(LTRIM(@objct_name)) = 0
	BEGIN
		SELECT @ErrorCodeStep4ObjAreasColumns = 401; -- Object name is missing
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
				1, --step 4
				0, --step 5
				0, --step 6
				0, --step 7
				@ObjectIdColumn,
				@ErrorCodeStep4ObjAreasColumns OUTPUT;

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep4ObjAreasColumns, 0) > 0
		BEGIN
			RETURN(-1);
		END
	END

	IF EXISTS (SELECT * FROM @MappedColumns)
	BEGIN
		INSERT INTO [dbo].[cg_meta_column]
           ([ref_version_id]
           ,[column_name]
           ,[ref_objct_name]
           ,[extract_flag_cd]
           ,[ref_area_name])
		SELECT
			@ref_version_id
			, [column_name]
			, @objct_name
			, 0
			, [area_name]
		FROM @MappedColumns
	END

END