SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_version_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_version_sel];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 03/09/2019
-- Revised date: 
-- Description : Select from [dbo].[cg_meta_version]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_version_sel]
AS
BEGIN
  SET NOCOUNT ON;

  SELECT * FROM [dbo].[cg_meta_version] ORDER BY [version_id];
END
