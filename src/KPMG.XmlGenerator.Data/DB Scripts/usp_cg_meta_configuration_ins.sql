SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_configuration_ins]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_configuration_ins];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 02/09/2019
-- Revised date: 10/09/2019
-- Description : Insert
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_configuration_ins]
  (@MapMetaVariantIdColumns nvarchar(max), @ref_version_id int,@configuration_name nvarchar(255), @ref_variant_name nvarchar(255)=NULL, @IdColumn int=NULL, @NewIdColumn int OUTPUT, @ErrorCode int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON
  SET XACT_ABORT ON
  BEGIN TRAN

  DECLARE @SQL NVARCHAR(max)

    IF @configuration_name IS NOT NULL AND LEN(LTRIM(RTRIM(@configuration_name))) > 0
	BEGIN
		IF @MapMetaVariantIdColumns IS NOT NULL AND LEN(LTRIM(RTRIM(@MapMetaVariantIdColumns))) > 0
		BEGIN
			SET @MapMetaVariantIdColumns = ','+@MapMetaVariantIdColumns+',';

			IF EXISTS (SELECT 1 FROM cg_meta_variant_config AS config
						INNER JOIN cg_meta_variant AS variant ON [variant].[variant_name] = [config].[ref_variant_name]
						WHERE UPPER([config].[configuration_name]) = UPPER(LTRIM(RTRIM(@configuration_name))) AND  CHARINDEX(','+cast(variant.IdColumn as varchar(8000))+',', @MapMetaVariantIdColumns) > 0)
			BEGIN
				SELECT @ErrorCode = 305; --configuration name and variant not unique
			END
			ELSE
			BEGIN

				INSERT INTO cg_meta_variant_config ([ref_version_id],[configuration_name],[ref_variant_name])
				SELECT DISTINCT @ref_version_id, @configuration_name, [variant_name]
				FROM [cg_meta_variant]
				WHERE [ref_version_id] = @ref_version_id
				AND CHARINDEX(','+cast(IdColumn as varchar(8000))+',', @MapMetaVariantIdColumns) > 0

				SELECT @NewIdColumn = SCOPE_IDENTITY();
			END
		END
		ELSE
			SELECT @ErrorCode = 306; --no variant ids are mapped
	END
	ELSE
		SELECT @ErrorCode = 301; --configuration name is missing

	COMMIT
END