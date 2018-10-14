select ORD_TID
from HamSFA.Order_tab
where Archived_NoSync = 0
  and (   USR_ID is null
       or USR_ID = @UsrId
       or (    @mode <> 'CREATOR'
           and ORD_Status not in ('Draft', 'Template')
          )
      )