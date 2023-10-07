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

			commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
			commandBinder.Bind(CommandEvent.StartGame).To<StartButtonCommand>();
			commandBinder.Bind(CommandEvent.QuitGame).To<QuitButtonCommand>();
		}
	}
}
