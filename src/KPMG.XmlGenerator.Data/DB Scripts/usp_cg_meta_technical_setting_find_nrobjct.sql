SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_cg_meta_technical_setting_find_nrobjct]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_cg_meta_technical_setting_find_nrobjct];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 26/09/2019
-- Revised date: 
-- Description : Find settings by nrobject and ref_version_id and return nrobjects
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_cg_meta_technical_setting_find_nrobjct]
	(@ref_version_id int,
     @page_size int = 50,
	 @skip int = 0,
     @filter nvarchar(255) = NULL)
AS
BEGIN
  SET NOCOUNT ON

  SELECT DISTINCT [nrobjct] 
  FROM [dbo].[cg_meta_technical_setting] 
  WHERE [ref_version_id] = @ref_version_id AND
		[nrobjct] LIKE 
			CASE 
				WHEN @filter IS NULL THEN '%' 
				ELSE '%' + @filter + '%' 
			END
  ORDER BY [nrobjct]
  OFFSET @skip ROWS 
  FETCH NEXT @page_size ROWS ONLY;

END