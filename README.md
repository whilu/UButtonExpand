# UButtonExpand

UGUI Button expand library.

## Screenshots

<img src="/screenshots/UButtonExpand_screen_record_1.0.0.gif" alt="UButtonExpand_screen_record_1.0.0.gif" title="UButtonExpand_screen_record_1.0.0.gif" width="729" height="300" />

## Usage

#### ButtonLongClickListener

Use it just like Button in UGUI!

#### PositionTransformer

Add this script to your Button object, then init with code:

```csharp
PositionTransformer mPositionTransformer;

void Start () {
	mPositionTransformer.init (10, PositionTransformer.TRANSFORM_DIRECTION.Y_AXIS);
}
```

**NOTE: If you want to use this in ScrollView, use ```ScrollviewPositionTransformer``` to replace ```PositionTransformer```.**

Enjoy it😄!

## Change logs

### 1.0.0(2018-12-3)
- Fix bug

### 0.9.0(2017-11-5)
- First release

## About

If you have any questions, contact me: [lujun.byte#gmail.com](mailto:lujun.byte@gmail.com).

## License

[MIT](LICENSE)
