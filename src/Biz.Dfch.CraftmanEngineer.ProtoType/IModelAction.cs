using System.Collections.Generic;
using biz.dfch.CS.Commons;

namespace Biz.Dfch.CraftmanEngineer.ProtoType
{
    public interface IModelAction
    {
        DictionaryParameters Invoke(DictionaryParameters parameters);
    }
}