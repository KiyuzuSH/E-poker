using strange.extensions.mediation.impl;
using System.Runtime.CompilerServices;

namespace Game
{
	public class InteractionMediator : EventMediator
	{
		[Inject] public InteractionView InteractionView { get; set; }

		public override void OnRegister()
		{
			InteractionView.btn_Deal.onClick.AddListener(onDealClick);
			dispatcher.AddListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);

		}

		public override void OnRemove()
		{
			InteractionView.btn_Deal.onClick.RemoveListener(onDealClick);
			dispatcher.RemoveListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);
		}

		#region »Øµ÷º¯Êý


		private void onDealClick()
		{
			dispatcher.Dispatch(CommandEvent.RequestDeal);
			InteractionView.DeactiveAll();
		}

		private void onCompleteDeal()
		{
			//dispatcher.Dispatch(CommandEvent.Test);
		}

		#endregion

	}
}
