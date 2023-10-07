using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace Game
{
    public class CharacterMediator : EventMediator
    {
        [Inject] public CharacterView CharacterView { get; set; }

		public override void OnRegister()
		{
			dispatcher.AddListener(CommandEvent.DealCard, onDealCard);
			dispatcher.AddListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);

		}

		public override void OnRemove()
		{
			dispatcher.RemoveListener(CommandEvent.DealCard, onDealCard);
			dispatcher.RemoveListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);
		}

		#region »Øµ÷º¯Êý

		private void onDealCard(IEvent evt)
		{
			DealCardArgs e = evt.data as DealCardArgs;
			CharacterView.AddCard(e.cType, e.card, e.selected);
		}

		private void onCompleteDeal(IEvent payload)
		{
			CharacterView.Player1.Sort();
			//CharacterView.PlayerL.Sort();
			//CharacterView.PlayerR.Sort();
			CharacterView.Desk.Sort(true);
		}

		#endregion

	}
}
