# test1

Unity 6 で作成した落下ブロック回避ゲームのテストプロジェクトです。

## ゲーム概要

上から落ちてくるブロックを左右に動いて避け続けるシンプルなアーケードゲームです。

## 操作方法

| キー | 動作 |
|------|------|
| ← / A | 左に移動 |
| → / D | 右に移動 |

## 開発環境

- Unity 6000.4.5f1
- Input System
- TextMesh Pro

## 実行方法

1. Unity Hub でプロジェクトを開く
2. `Assets/Scenes/SampleScene` を開く
3. Play ボタンで実行

## プロジェクト構成

```
Assets/
├── Scenes/          # ゲームシーン
├── Scripts/
│   ├── GameManager.cs      # スコア・ゲームオーバー管理
│   ├── PlayerController.cs # プレイヤー移動・当たり判定
│   ├── FallingBlock.cs     # 落下ブロック挙動
│   └── BlockSpawner.cs     # ブロック生成制御
├── Settings/        # Input System 設定
└── TextMesh Pro/    # TMP アセット
```
