# UButtonExpand

UGUI Button expand library.

## Usage

#### ButtonLongClickListener

Use it just like Button in UGUI!

#### PositionTransformer

Add this script to your Button object, then init with code:

```csharp
PositionTransformer mPositionTransformer;

void Start () {
	mPositionTransformer.init (5, PositionTransformer.TRANSFORM_DIRECTION.X_AXIS);
}
```

**NOTE: If you want to use this in ScrollView, use ```ScrollviewPositionTransformer``` to replace ```PositionTransformer```.**

Enjoy it😄!

## Change logs

### 0.9.0(2017-11-5)
- First release

## About

If you have any questions, contact me: [lujun.byte#gmail.com](mailto:lujun.byte@gmail.com).

## License

[MIT](LICENSE)
