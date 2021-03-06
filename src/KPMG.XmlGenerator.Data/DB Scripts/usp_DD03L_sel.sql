SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('[dbo].[usp_DD03L_sel]', 'P') IS NOT NULL
  DROP PROCEDURE [dbo].[usp_DD03L_sel];

GO

-- ===================================================================
-- Author      : KPMG
-- Create date : 19/09/2019
-- Revised date:
-- Description : Select from [dbo].[DD03L]
-- ===================================================================

CREATE PROCEDURE [dbo].[usp_DD03L_sel]
  (@TABNAME nvarchar(30), @FIELDNAME nvarchar(30) = NULL)
AS
BEGIN
  SET NOCOUNT ON;

  SELECT
    [TABNAME],
    [FIELDNAME],
    [KEYFLAG]
    FROM [dbo].[DD03L] WHERE
    [FIELDNAME] NOT LIKE '.INCLU%' AND
    [TABNAME] = @TABNAME AND
    [FIELDNAME] = CASE WHEN @FIELDNAME IS NULL THEN [FIELDNAME] ELSE @FIELDNAME END
    ORDER BY [TABNAME], [KEYFLAG] DESC, [FIELDNAME];

END
