using MyHeroKill.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeroKill.Model.Skills
{
    public class BawangSkill : BaseSkill
    {
        public BawangSkill()
        {
            this.Name = "霸王";
            this.AddAttackDistance = 0;
            this.AddDamage = 0;
            this.AddLife = 0;
            this.AddAttackCount = 0;
            this.CanProvideJuedou = false;
            this.CanProvideSha = false;
            this.CanProvideShan = false;
            this.CanProvideWuxiekeji = false;
            this.CanProvideYao = false;
            this.SkillType = Enums.ESkillType.MainSkill;
        }

        public override void OnBeforeSha(HandCardManager handCardManager)
        {
            //在杀之前，被攻击方需要出两张闪
            var cardModel = handCardManager.GetCardModel();
            var needShan = cardModel.NeedHandoutCards.FirstOrDefault(p => p.NeedHandoutGloabalTypes == Enums.ECardGloabalType.Shan);
            needShan.NeedHandoutCardCount = 2;
            handCardManager.SetCardModel(cardModel);
        }

        public override void OnAskJuedou()
        {
            //在决斗之前，被攻击方需要出两张杀
        }
    }
}
