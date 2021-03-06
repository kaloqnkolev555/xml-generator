SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_variant_ins]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_variant_ins];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 02/09/2019
-- Revised date: 27/09/2019
-- Description : Insert new variant
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_variant_ins] (
  @TemplateVariantIdColumn int = NULL,
  @MapMetaObjctIdColumns nvarchar(MAX) = NULL,
  @ref_version_id int,
  @variant_name nvarchar(255),
  @description nvarchar(200) = NULL,
  @IdColumn int = NULL,
  @NewIdColumn int OUTPUT,
  @ErrorCode int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON
  SET XACT_ABORT ON

  IF @variant_name IS NOT NULL AND LEN(LTRIM(RTRIM(@variant_name))) > 0
  BEGIN
    BEGIN TRAN

    INSERT INTO [dbo].[cg_meta_variant]
      ([ref_version_id],[variant_name],[description])
      VALUES
      (@ref_version_id, @variant_name, @description);

    SELECT @NewIdColumn = SCOPE_IDENTITY();

    IF @TemplateVariantIdColumn IS NOT NULL
    BEGIN

      INSERT INTO [dbo].[cg_meta_variant_objct]
        ([ref_version_id], [ref_objct_name], [ref_variant_name], [ref_extraction_logic_name])
        SELECT DISTINCT @ref_version_id, vo.[ref_objct_name], @variant_name, vo.[ref_extraction_logic_name]
          FROM [cg_meta_variant_objct] AS vo
          WHERE vo.[ref_version_id] = @ref_version_id AND
                vo.[ref_variant_name] = (SELECT [variant_name] FROM [dbo].[cg_meta_variant] WHERE [IdColumn] = @TemplateVariantIdColumn);

    END
    ELSE IF @MapMetaObjctIdColumns IS NOT NULL
    BEGIN

      SET @MapMetaObjctIdColumns = N',' + @MapMetaObjctIdColumns + ',';

      INSERT INTO [dbo].[cg_meta_variant_objct]
        (ref_version_id, ref_variant_name, ref_objct_name, ref_extraction_logic_name)
        SELECT DISTINCT @ref_version_id, @variant_name, ob.[objct_name], (SELECT MAX([ref_extraction_logic_name]) FROM [dbo].[cg_meta_technical_setting] WHERE [ref_objct_name] = ob.[objct_name] and [ref_version_id] = @ref_version_id)
          FROM [cg_meta_objct] AS ob
          WHERE ob.[ref_version_id] = @ref_version_id AND
                CHARINDEX(',' + CAST(ob.[IdColumn] AS varchar(30)) + ',', @MapMetaObjctIdColumns) > 0
    END

    COMMIT
  END
  ELSE
    SELECT @ErrorCode = 201; -- Variant name is missing
END