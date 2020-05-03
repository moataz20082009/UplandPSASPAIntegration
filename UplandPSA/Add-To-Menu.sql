INSERT INTO TMENU ([URL]
      ,[PREFETCHURL]
      ,[SHORTDESC]
      ,[DESCHOLDER]
      ,[SMVISIBLE]
      ,[ISCUSTOM]
      ,[BROWSERTYPE]
      ,[MENUCONTAINERURL]
      ,[NONIEURL]
      ,[IMGURL])
values('SitemapRedirect(''../../Entry/Common/UplandPSAClientIntiator.aspx'
	  ,''
	  ,'UplandPSA Client'
	  ,0
	  ,2
	  ,0
	  ,3
	  ,null
	  ,null
	  ,'TLogo.png')

DECLARE @MENUID INT = SCOPE_IDENTITY()
INSERT INTO TMENUDESC
(
[MENUUID]
      ,[LANGUAGE]
      ,[TITLE]
      ,[DESCRIPTION]
)
VALUES
(
	@MENUID
	, 0
	, 'Upland PSA Client'
	, 'Upland PSA Client'
)
INSERT INTO TMENUDESC
(
[MENUUID]
      ,[LANGUAGE]
      ,[TITLE]
      ,[DESCRIPTION]
)
VALUES
(
	@MENUID
	, 1
	, 'Upland PSA Client'
	, 'Upland PSA Client'
)

insert into [TMENUPERS](
[MENUUID]
      ,[OBJECTTYPE]
      ,[OBJECTID]
      ,[LEVELID]
      ,[PARENT]
      ,[HIERARCHY]
      ,[ISENABLED]
      ,[ISFRAMED]
      ,[ISUNDERMENU]
)
values
(
	@MENUID,-1,-1,2,10,2,1,0,0
)
insert into [TMENUPERS](
[MENUUID]
      ,[OBJECTTYPE]
      ,[OBJECTID]
      ,[LEVELID]
      ,[PARENT]
      ,[HIERARCHY]
      ,[ISENABLED]
      ,[ISFRAMED]
      ,[ISUNDERMENU]
)
values
(
	@MENUID,152,5,2,10,2,1,0,0
)
