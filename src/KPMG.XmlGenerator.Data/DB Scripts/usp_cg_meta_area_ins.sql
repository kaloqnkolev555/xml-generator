SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_area_ins]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_area_ins];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 02/09/2019
-- Revised date: 26/09/2019
-- Description : Insert
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_area_ins] (
  @TemplateAreaIdColumn int = NULL,
  @MapMetaObjctIdColumns nvarchar(MAX) = NULL,
  @ref_version_id int,
  @area_name nvarchar(255),
  @description nvarchar(200) = NULL,
  @IdColumn int = NULL,
  @NewIdColumn int OUTPUT,
  @ErrorCode int OUTPUT)
AS
BEGIN
  SET NOCOUNT ON
  SET XACT_ABORT ON
  BEGIN TRAN

  IF @area_name IS NOT NULL AND LEN(LTRIM(@area_name)) > 0
  BEGIN

    INSERT INTO [dbo].[cg_meta_area]
        ([ref_version_id],[area_name],[description])
      VALUES
        (@ref_version_id, @area_name, @description);

    SELECT @NewIdColumn = SCOPE_IDENTITY();

    IF @TemplateAreaIdColumn IS NOT NULL
    BEGIN

      DECLARE @template_area_name nvarchar(255);
      SELECT @template_area_name = [area_name] FROM [dbo].[cg_meta_area] WHERE [IdColumn] = @TemplateAreaIdColumn;

      IF @template_area_name IS NOT NULL
      BEGIN

        INSERT INTO [dbo].[cg_meta_area_to_objct]
          ([ref_version_id], [ref_objct_id], [ref_area_name])
          SELECT DISTINCT @ref_version_id, tmpl.[ref_objct_id], @area_name
            FROM [dbo].[cg_meta_area_to_objct] AS tmpl
            WHERE tmpl.[ref_version_id] = @ref_version_id AND tmpl.[ref_area_name] = @template_area_name;

        INSERT INTO [dbo].[cg_meta_column]
          ([ref_version_id], [column_name], [ref_objct_name], [extract_flag_cd], [ref_area_name])
          SELECT DISTINCT @ref_version_id, tmpl.[column_name], tmpl.[ref_objct_name], tmpl.[extract_flag_cd], @area_name
            FROM [dbo].[cg_meta_column] AS tmpl
            WHERE tmpl.[ref_version_id] = @ref_version_id AND tmpl.[ref_area_name] = @template_area_name;

        INSERT INTO [dbo].[cg_meta_constraint_to_area]
          ([ref_version_id], [ref_extraction_logic_name], [ref_objct_name], [conField], [conOption], [conValue], [InSQL], [ref_area_id], [priority])
          SELECT DISTINCT @ref_version_id, tmpl.[ref_extraction_logic_name], tmpl.[ref_objct_name], tmpl.[conField], tmpl.[conOption], tmpl.[conValue], tmpl.[InSQL], @area_name, tmpl.[priority]
            FROM [dbo].[cg_meta_constraint_to_area] AS tmpl
            WHERE  tmpl.[ref_version_id] = @ref_version_id AND  tmpl.[ref_area_id] = @template_area_name;

        INSERT INTO [dbo].[cg_meta_hconstraint_to_area]
          ([ref_version_id], [ref_extraction_logic_name], [hconstraint_name], [ref_objct_name], [conLine], [conContent], [ref_area_id], [priority], [is_complex_line], [is_default_no_constraint])
          SELECT DISTINCT @ref_version_id, tmpl.[ref_extraction_logic_name], tmpl.[hconstraint_name], tmpl.[ref_objct_name], tmpl.[conLine], tmpl.[conContent], @area_name, tmpl.[priority], tmpl.[is_complex_line], tmpl.[is_default_no_constraint]
            FROM [dbo].[cg_meta_hconstraint_to_area] AS tmpl
            WHERE tmpl.[ref_version_id] = @ref_version_id AND tmpl.[ref_area_id] = @template_area_name;

        INSERT INTO cg_meta_scope ([ref_version_id],[scope_name],[order],[tag],[value],[isScope],[abap_version],[ref_area_name])
          SELECT DISTINCT @ref_version_id, tmpl.[scope_name], tmpl.[order], tmpl.[tag], tmpl.[value], tmpl.[isScope], tmpl.[abap_version], @area_name
            FROM [dbo].[cg_meta_scope] AS tmpl
            WHERE tmpl.[ref_version_id] = @ref_version_id AND tmpl.[ref_area_name] = @template_area_name;

      END
    END
    ELSE IF @MapMetaObjctIdColumns IS NOT NULL
    BEGIN
      SET @MapMetaObjctIdColumns = ','+@MapMetaObjctIdColumns+',';

      WITH [obj] AS
      (
        SELECT [objct_name]
          FROM [dbo].[cg_meta_objct]
          WHERE CHARINDEX(',' + CAST([IdColumn] as varchar(30)) + ',', @MapMetaObjctIdColumns) > 0
      )
      INSERT INTO [dbo].[cg_meta_area_to_objct]
        ([ref_version_id], [ref_objct_id], [ref_area_name])
        SELECT DISTINCT @ref_version_id, [objct_name], @area_name
          FROM [obj]
    END

    COMMIT
  END
  ELSE
      SELECT @ErrorCode = 101; -- Area name is missing
END
