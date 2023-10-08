using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Game
{
	public class GameContext : MVCSContext
	{
		public GameContext(MonoBehaviour view, bool autoMapping):base(view, autoMapping) { }

		/// <summary> ∞Û∂®”≥…‰ </summary>
		protected override void mapBindings()
		{
			injectionBinder.Bind<CardModel>().To<CardModel>().ToSingleton();
			injectionBinder.Bind<RoundModel>().To<RoundModel>().ToSingleton();

			mediationBinder.BindView<StartView>().ToMediator<StartMediator>();
			mediationBinder.BindView<InteractionView>().ToMediator<InteractionMediator>();
			mediationBinder.Bind<CharacterView>().To<CharacterMediator>();

			commandBinder.Bind(CommandEvent.StartGame).To<StartButtonCommand>();
			commandBinder.Bind(CommandEvent.QuitGame).To<QuitButtonCommand>();
			commandBinder.Bind(CommandEvent.RequestDeal).To<RequestDealCommand>();
			commandBinder.Bind(CommandEvent.PlayCard).To<PlayCardCommand>();
			commandBinder.Bind(CommandEvent.PassCard).To<PassCardCommand>();
			commandBinder.Bind(CommandEvent.GameOver).To<GameOverCommand>();

			commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
		}
	}
}
