﻿// このファイルで必要なライブラリのnamespaceを指定
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using SyokumotsuRensa.CSV;
using SyokumotsuRensa.Music;
using SyokumotsuRensa.Scene;

/// <summary>
/// プロジェクト名がnamespaceとなります
/// </summary>
namespace SyokumotsuRensa
{
    /// <summary>
    /// ゲームの基盤となるメインのクラス
    /// 親クラスはXNA.FrameworkのGameクラス
    /// </summary>
    public class Game1 : Game
    {
        // フィールド（このクラスの情報を記述）
        private GraphicsDeviceManager graphicsDeviceManager;//グラフィックスデバイスを管理するオブジェクト
       // private SpriteBatch spriteBatch;//画像をスクリーン上に描画するためのオブジェクト

        private GameDevice gameDevice;

        Renderer renderer;
        SceneManager sceneManager;
        private BGMLoader bgmLoader;


        /// <summary>
        /// コンストラクタ
        /// （new で実体生成された際、一番最初に一回呼び出される）
        /// </summary>
        public Game1()
        {
            //グラフィックスデバイス管理者の実体生成
            graphicsDeviceManager = new GraphicsDeviceManager(this);
            //コンテンツデータ（リソースデータ）のルートフォルダは"Contentに設定
            Content.RootDirectory = "Content";

            //IsMouseVisible = true;


            graphicsDeviceManager.PreferredBackBufferWidth = Screen.ScreenWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = Screen.ScreenHeight;
        }

        /// <summary>
        /// 初期化処理（起動時、コンストラクタの後に1度だけ呼ばれる）
        /// </summary>
        protected override void Initialize()
        {
            // この下にロジックを記述
            gameDevice = GameDevice.Instance(Content, GraphicsDevice);
            Window.Title="うんこ";
            sceneManager = new SceneManager();
            sceneManager.Add(SceneName.Title,new Title());
            sceneManager.Add(SceneName.Load, new Load());
            IScene addScene = new GamePlay();
            sceneManager.Add(SceneName.GamePlay, addScene);
   
          

            sceneManager.Change(SceneName.Title);
            bgmLoader = new BGMLoader(new string[,] { { "GamePlay1", "./Sound/" } });
            bgmLoader.Initialize();
            // この上にロジックを記述
            base.Initialize();// 親クラスの初期化処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// コンテンツデータ（リソースデータ）の読み込み処理
        /// （起動時、１度だけ呼ばれる）
        /// </summary>
        protected override void LoadContent()
        {
            // 画像を描画するために、スプライトバッチオブジェクトの実体生成
          //  spriteBatch = new SpriteBatch(GraphicsDevice);

            // この下にロジックを記述
           // renderer = new Renderer(Content, GraphicsDevice);
            renderer = gameDevice.GetRenderer();
            renderer.LoadContent("BlueTile");
            renderer.LoadContent("RedTile");
            renderer.LoadContent("chicken");
            renderer.LoadContent("glass");
            renderer.LoadContent("house");
            renderer.LoadContent("number");
            renderer.LoadContent("pig");
            renderer.LoadContent("tile");
            renderer.LoadContent("unchi");
            renderer.LoadContent("whiteunchi");
            renderer.LoadContent("wolf");
            renderer.LoadContent("wolf2");
            renderer.LoadContent("GameOver");
            renderer.LoadContent("horizontalFence");
            renderer.LoadContent("verticalFence");
            renderer.LoadContent("GameClear");
            renderer.LoadContent("hand");
            renderer.LoadContent("heart");
            renderer.LoadContent("meat");
            renderer.LoadContent("exclamation");
            renderer.LoadContent("eagle");
            renderer.LoadContent("rion");
            renderer.LoadContent("cow");
            renderer.LoadContent("chicken");
            renderer.LoadContent("hand2");
            renderer.LoadContent("UI");
            renderer.LoadContent("ring");
            renderer.LoadContent("title_image");
            renderer.LoadContent("titleUI_hajimeru");
            renderer.LoadContent("titleUI_owaru");
            renderer.LoadContent("big_whiteunchi");
            renderer.LoadContent("futsukame");
            renderer.LoadContent("ichinichime");
            renderer.LoadContent("mikkame");
            renderer.LoadContent("nextday");
            renderer.LoadContent("resultUI_retry");
            renderer.LoadContent("resultUI_title");
            renderer.LoadContent("titleUI_setsumei");
            renderer.LoadContent("yajirushi");
            renderer.LoadContent("tutorial1");
            renderer.LoadContent("tutorial2");
            renderer.LoadContent("tutorial3");
            renderer.LoadContent("arrowhukidashi");
            renderer.LoadContent("hidarikun");
            renderer.LoadContent("tojiru");
            renderer.LoadContent("slash");
            renderer.LoadContent("rion_redeyes");
            renderer.LoadContent("eagle_redeyes");
            renderer.LoadContent("wolf_redeyes");
            renderer.LoadContent("Yoru");
            renderer.LoadContent("suna");
            // この上にロジックを記述
        }

        /// <summary>
        /// コンテンツの解放処理
        /// （コンテンツ管理者以外で読み込んだコンテンツデータを解放）
        /// </summary>
        protected override void UnloadContent()
        {
            // この下にロジックを記述


            // この上にロジックを記述
        }

        /// <summary>
        /// 更新処理
        /// （1/60秒の１フレーム分の更新内容を記述。音再生はここで行う）
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Update(GameTime gameTime)
        {
            // ゲーム終了処理（ゲームパッドのBackボタンかキーボードのエスケープボタンが押されたら終了）
            if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                 (Keyboard.GetState().IsKeyDown(Keys.Escape)) || GameEndFlag.gameEndFlag)
            {
                Exit();
            }

            // この下に更新ロジックを記述

          
            gameDevice.Update(gameTime);
            sceneManager.Update(gameTime);

            // この上にロジックを記述
            base.Update(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }

        /// <summary>
        /// 描画処理
        /// </summary>
        /// <param name="gameTime">現在のゲーム時間を提供するオブジェクト</param>
        protected override void Draw(GameTime gameTime)
        {
            // 画面クリア時の色を設定
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // この下に描画ロジックを記述
            //renderer.Begin();

            sceneManager.Draw(renderer);
            //renderer.End();

            //この上にロジックを記述
            base.Draw(gameTime); // 親クラスの更新処理呼び出し。絶対に消すな！！
        }
    }
}
