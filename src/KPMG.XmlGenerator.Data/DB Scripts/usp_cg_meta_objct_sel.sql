SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- drop SP if it exists
IF OBJECT_ID('[dbo].[usp_cg_meta_objct_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_objct_sel];

GO
-- ===================================================================
-- Author      : KPMG
-- Create date : 03/09/2019
-- Revised date:
-- Description : Select from [dbo].[cg_meta_objct]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_objct_sel]
  (@IdColumn int=NULL, @ref_version_id int = NULL)
AS
BEGIN
  SET NOCOUNT ON

  IF @IdColumn IS NULL
    SELECT
        [o].[ref_version_id]
        ,[o].[objct_name]
        ,[o].[ref_group_name]
        ,[o].[ref_table_name]
        ,[o].[is_footer]
        ,[o].[Description]
        ,[o].[is_default]
        ,[o].[IdColumn]
        ,[hf].[ref_objct_name] AS [HeaderObjectName]
        ,[hf].[footer_fileName] AS [FooterFileName]
        ,[hf].[footer_hashtotalField] AS [FooterHashTotalField]
    FROM [dbo].[cg_meta_objct] AS [o]
    LEFT OUTER JOIN [dbo].[cg_meta_header_footer] AS [hf] ON [hf].[ref_version_id] = [o].[ref_version_id] AND [hf].[ref_table_name] = [o].[objct_name]
    WHERE [o].[ref_version_id] = CASE WHEN @ref_version_id IS NULL THEN [o].[ref_version_id] ELSE @ref_version_id END
    ORDER BY [o].[objct_name], [o].[IdColumn];
  ELSE
    SELECT
        [o].[ref_version_id]
        ,[o].[objct_name]
        ,[o].[ref_group_name]
        ,[o].[ref_table_name]
        ,[o].[is_footer]
        ,[o].[Description]
        ,[o].[is_default]
        ,[o].[IdColumn]
        ,[hf].[ref_objct_name] AS [HeaderObjectName]
        ,[hf].[footer_fileName] AS [FooterFileName]
        ,[hf].[footer_hashtotalField] AS [FooterHashTotalField]
    FROM [dbo].[cg_meta_objct] AS [o]
    LEFT OUTER JOIN [dbo].[cg_meta_header_footer] AS [hf] ON [hf].[ref_version_id] = [o].[ref_version_id] AND [hf].[ref_table_name] = [o].[objct_name]
    WHERE [o].[IdColumn] = @IdColumn;

END