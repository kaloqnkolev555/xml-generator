SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_configuration_ups]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_configuration_ups];
GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 02/09/2019
-- Revised date: 27/09/2019
-- Description : Map variant(s) to configuration
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_configuration_ups] (
  @ref_version_id int,
  @configuration_name nvarchar(255),
  @MapMetaVariantIdColumns nvarchar(MAX) = NULL,
  @IdColumn int = NULL,
  @NewIdColumn int OUTPUT,
  @ErrorCode int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON
  SET XACT_ABORT ON

  IF @IdColumn IS NOT NULL
  BEGIN

    SELECT @ref_version_id = [ref_version_id], @configuration_name = [configuration_name] FROM [dbo].[cg_meta_variant_config] WHERE [IdColumn] = @IdColumn;

    -- Check if configuration exists
    IF @configuration_name IS NOT NULL AND LEN(LTRIM(@configuration_name)) > 0
    BEGIN

      -- check if something needs to be mapped
      IF @MapMetaVariantIdColumns IS NOT NULL AND LEN(LTRIM(@MapMetaVariantIdColumns)) > 0
      BEGIN

        SET @MapMetaVariantIdColumns = N',' + @MapMetaVariantIdColumns + N',';

        DECLARE @variant_names TABLE([variant_name] nvarchar(255));

        INSERT INTO @variant_names ([variant_name])
          SELECT [variant_name]
            FROM [dbo].[cg_meta_variant]
            WHERE CHARINDEX(N',' + CAST([IdColumn] AS varchar(30)) + N',', @MapMetaVariantIdColumns) > 0;

        IF EXISTS(SELECT 1 FROM @variant_names)
        BEGIN
          BEGIN TRAN

          -- delete unmapped
          DELETE [dbo].[cg_meta_variant_config]
            WHERE [ref_version_id] = @ref_version_id AND
                  [configuration_name] = @configuration_name AND
                  [ref_variant_name] NOT IN (SELECT [variant_name] FROM @variant_names);

          -- insert newly mapped
          INSERT INTO [dbo].[cg_meta_variant_config]
            ([ref_version_id], [configuration_name], [ref_variant_name])
            SELECT DISTINCT @ref_version_id, @configuration_name, [variant_name]
              FROM @variant_names
              WHERE [variant_name] NOT IN (SELECT [ref_variant_name] FROM [dbo].[cg_meta_variant_config] WHERE [ref_version_id] = @ref_version_id AND [configuration_name] = @configuration_name);

          COMMIT
        END
        ELSE
          SELECT @ErrorCode = 306; -- No variants were provided for mapping
      END
      ELSE
        SELECT @ErrorCode = 306; -- No variants were provided for mapping
    END
    ELSE
      SELECT @ErrorCode = 301; -- Configuration name is missing
  END
  ELSE
    SELECT @ErrorCode = 304; -- No configuration was selected to update variant mapping

END