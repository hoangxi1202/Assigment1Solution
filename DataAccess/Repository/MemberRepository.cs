﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    internal class MemberRepository
    {
         public IEnumerable<MemberObject> SortDesByName() => MemberDAO.Instance.SortDesByName();
    }
}
