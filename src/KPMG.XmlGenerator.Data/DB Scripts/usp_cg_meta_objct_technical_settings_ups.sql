SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_objct_technical_settings_ups]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_technical_settings_ups];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 07/10/2019
-- Revised date: 18/10/2019
-- Description : Create or update the technical settings for an object
-- that is being created or updated
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_technical_settings_ups]
	(@ref_version_id int,
	@objct_name nvarchar(255),
	@extraction_logic_name nvarchar(255),
	@helperTable_name nvarchar(255),
	@dayByDay nvarchar(255),
	@daysPerLoop int,
	@nrobjct nvarchar(255),
	@nrfield nvarchar(255),
	@nrMin bit,
	@nrMax bit,
	@parallel int,
	@pkgSize int,
	@pkgSize2 int,
	@xFilename nvarchar(255),
	@hashtotalField nvarchar(255),
	@is_default bit,
	@docNbr nvarchar(50),
	@loopAt nvarchar(50),
	@ObjectIdColumn int=NULL,
	@NewTSIdColumn int OUTPUT,
	@ErrorCodeStep2ObjTechnicalSettings int OUTPUT)
AS
BEGIN
	SET NOCOUNT ON

	IF @objct_name IS NULL OR LEN(LTRIM(@objct_name)) = 0
	BEGIN
		SELECT @ErrorCodeStep2ObjTechnicalSettings = 401; -- Object name is missing
		RETURN(-1);
	END

	IF @ObjectIdColumn IS NOT NULL
	BEGIN
		DECLARE @RetVal int;

		EXEC @RetVal = [dbo].[usp_cg_meta_objct_del] @ref_version_id,
				@objct_name,
				0, --step 1
				1, --step 2
				1, --step 3
				1, --step 4
				1, --step 5
				1, --step 6
				1, --step 7
				@ObjectIdColumn,
				@ErrorCodeStep2ObjTechnicalSettings OUTPUT;

		IF @RetVal = -1 OR ISNULL(@ErrorCodeStep2ObjTechnicalSettings, 0) > 0
		BEGIN
			RETURN(-1);
		END
	END

	-- user has option to add new helper table, we have to add it to the maste table due to the foreign key constraint
	IF ISNULL(@helperTable_name, '') <> '' AND
        NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_helperTable] WHERE ref_version_id = @ref_version_id AND helperTable_name = @helperTable_name)
	BEGIN
		INSERT INTO [dbo].[cg_meta_helperTable]
           ([ref_version_id]
           ,[helperTable_name])
		VALUES
           (@ref_version_id
           ,@helperTable_name)
	END

	INSERT INTO [dbo].[cg_meta_technical_setting]
           ([ref_version_id]
           ,[ref_objct_name]
           ,[ref_extraction_logic_name]
           ,[ref_helperTable_name]
           ,[dayByDay]
           ,[daysPerLoop]
           ,[nrobjct]
           ,[nrfield]
           ,[nrMin]
           ,[nrMax]
           ,[parallel]
           ,[pkgSize]
           ,[pkgSize2]
           ,[xFilename]
           ,[hashtotalField]
           ,[is_default_setting]
           ,[docNbr]
           ,[loopAt])
    VALUES
           (@ref_version_id
           ,@objct_name
           ,@extraction_logic_name
           ,ISNULL(@helperTable_name, '')
           ,ISNULL(@dayByDay, '')
           ,ISNULL(@daysPerLoop, 0)
           ,ISNULL(@nrobjct, '')
           ,ISNULL(@nrfield, '')
           ,ISNULL(@nrMin, 0)
           ,ISNULL(@nrMax, 0)
           ,ISNULL(@parallel, 0)
           ,ISNULL(@pkgSize, 0)
           ,ISNULL(@pkgSize2, 0)
           ,ISNULL(@xFilename, '')
           ,ISNULL(@hashtotalField, '')
           ,@is_default
           ,ISNULL(@docNbr, '')
           ,ISNULL(@loopAt, ''))

	SELECT @NewTSIdColumn = SCOPE_IDENTITY();
END