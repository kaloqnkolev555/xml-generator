USE [_META_XML_GENERATOR_GENERIC]
GO

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'BALOBJT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'BALOBJT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'BALOBJT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'BALSUBT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'BALSUBT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'BALSUBT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'DBTABPRT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'DBTABPRT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'DBTABPRT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'DD01L')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'DD01L', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'DD01L', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'DD07L')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'DD07L', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'DD07L', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'DD32S')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'DD32S', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'DD32S', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'EDBAST')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'EDBAST', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'EDBAST', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'EDIMSGT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'EDIMSGT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'EDIMSGT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'ENHOBJ')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'ENHOBJ', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'ENHOBJ', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'ENHSPOTCOMPHEAD')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'ENHSPOTCOMPHEAD', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'ENHSPOTCOMPHEAD', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'FUNCT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'FUNCT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'FUNCT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'MODTEXT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'MODTEXT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'MODTEXT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'SEOCLASSTX')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'SEOCLASSTX', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'SEOCLASSTX', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'SMODILOG')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'SMODILOG', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'SMODILOG', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'SMODIUSER')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'SMODIUSER', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'SMODIUSER', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T001A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T001A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T001A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T001CM')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T001CM', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T001CM', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T001Z')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T001Z', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T001Z', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T003P')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T003P', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T003P', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T005X')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T005X', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T005X', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T006B')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T006B', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T006B', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T006D')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T006D', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T006D', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T011T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T011T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T011T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T012')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T012', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T012', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T024D')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T024D', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T024D', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T024Z')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T024Z', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T024Z', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030B')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030B', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030B', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030C')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030C', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030C', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030D')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030D', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030D', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030E')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030E', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030E', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030G')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030G', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030G', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030H')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030H', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030H', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030HB')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030HB', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030HB', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030I')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030I', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030I', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030S')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030S', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030S', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T030W')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T030W', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T030W', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T040A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T040A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T040A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T042I')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T042I', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T042I', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T043S')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T043S', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T043S', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T044A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T044A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T044A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T047A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T047A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T047A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T047M')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T047M', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T047M', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T074')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T074', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T074', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T082A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T082A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T082A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T082B')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T082B', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T082B', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T082F')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T082F', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T082F', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T082G')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T082G', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T082G', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T095P')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T095P', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T095P', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T149B')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T149B', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T149B', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T156C')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T156C', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T156C', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T156SC')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T156SC', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T156SC', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T156SY')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T156SY', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T156SY', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T162T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T162T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T162T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T169A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T169A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T169A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T169D')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T169D', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T169D', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T169P')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T169P', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T169P', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T16FG')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T16FG', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T16FG', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T16FH')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T16FH', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T16FH', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T171T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T171T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T171T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T411T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T411T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T411T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T412T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T412T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T412T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T418T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T418T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T418T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T438S')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T438S', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T438S', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T438T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T438T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T438T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T438X')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T438X', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T438X', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T441R')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T441R', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T441R', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T441V')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T441V', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T441V', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T441W')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T441W', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T441W', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T461X')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T461X', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T461X', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T529T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T529T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T529T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T530T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T530T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T530T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T542A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T542A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T542A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T549A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T549A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T549A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T556A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T556A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T556A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T628T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T628T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T628T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T681W')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T681W', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T681W', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T685Z')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T685Z', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T685Z', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T687T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T687T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T687T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T691A')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T691A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T691A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T691D')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T691D', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T691D', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T691F')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T691F', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T691F', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T691G')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T691G', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T691G', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T6B1T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T6B1T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T6B1T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'T778O')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'T778O', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'T778O', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TCA01')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TCA01', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TCA01', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TCJ1T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TCJ1T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TCJ1T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TCLA')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TCLA', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TCLA', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TCLAO')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TCLAO', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TCLAO', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TCLO')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TCLO', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TCLO', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TCLT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TCLT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TCLT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TCURE')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TCURE', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TCURE', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TCURV')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TCURV', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TCURV', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TCURW')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TCURW', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TCURW', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TFACD')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TFACD', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TFACD', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TFPLB')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TFPLB', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TFPLB', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TFRMT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TFRMT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TFRMT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'THOC')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'THOC', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'THOC', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TJ02T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TJ02T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TJ02T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TJ20')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TJ20', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TJ20', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TJ20T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TJ20T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TJ20T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TJ30')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TJ30', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TJ30', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TJ30T')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TJ30T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TJ30T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TKA00')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TKA00', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TKA00', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TKA3A')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TKA3A', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TKA3A', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TKSKA')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TKSKA', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TKSKA', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TKT09')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TKT09', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TKT09', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TLIBT')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TLIBT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TLIBT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TMODU')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TMODU', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TMODU', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TMVF')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TMVF', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TMVF', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TMVFT')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TMVFT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TMVFT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TOJTT')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TOJTT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TOJTT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TPAKL')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TPAKL', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TPAKL', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TPS01')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TPS01', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TPS01', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TQ02U')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TQ02U', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TQ02U', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TQ80_T')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TQ80_T', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TQ80_T', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TTZ5')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TTZ5', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TTZ5', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVAG')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVAG', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVAG', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVCPF')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVCPF', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVCPF', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVCPT')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVCPT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVCPT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVEP')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVEP', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVEP', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVEPZ')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVEPZ', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVEPZ', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVFP')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVFP', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVFP', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVGRT')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVGRT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVGRT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVKT')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVKT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVKT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVKTT')

BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVKTT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVKTT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVLP')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVLP', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVLP', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVLS')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVLS', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVLS', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVLSP')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVLSP', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVLSP', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVLVT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVLVT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVLVT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVMS')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVMS', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVMS', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVSWZ')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVSWZ', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVSWZ', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVTKT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVTKT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVTKT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVUVS')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVUVS', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVUVS', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'TVZBT')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'TVZBT', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'TVZBT', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'USRPWDHISTORY')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'USRPWDHISTORY', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'USRPWDHISTORY', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'USVART')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'USVART', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'USVART', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'USZBVLNDSC')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'USZBVLNDSC', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'USZBVLNDSC', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'VEPHEADER')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'VEPHEADER', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'VEPHEADER', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'VTCESYST')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'VTCESYST', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'VTCESYST', N'', 1, N'', N'')
END

IF NOT EXISTS (SELECT 1 FROM [dbo].[cg_meta_technical_setting] WHERE ref_version_id = 15 AND [ref_objct_name] = N'WSHEADER')
BEGIN
INSERT [dbo].[cg_meta_technical_setting] ([ref_version_id], [ref_objct_name], [ref_extraction_logic_name], [ref_helperTable_name], [dayByDay], [daysPerLoop], [nrobjct], [nrfield], [nrMin], [nrMax], [parallel], [pkgSize], [pkgSize2], [xFilename], [hashtotalField], [is_default_setting], [docNbr], [loopAt]) VALUES (15, N'WSHEADER', N'9', N'', N'', 0, N'', N'', 0, 0, 0, 0, 0, N'WSHEADER', N'', 1, N'', N'')
END

