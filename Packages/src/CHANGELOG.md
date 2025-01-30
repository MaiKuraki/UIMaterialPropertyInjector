# [1.1.0](https://github.com/mob-sakai/UIMaterialPropertyInjector/compare/1.0.4...1.1.0) (2025-01-30)


### Bug Fixes

* ignore properties with `Toggle`, `KeywordEnum` and `PerRendererData` attributes ([343d9e5](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/343d9e5a51a396fe083fb0b41f2cd3cd18dc5afa))


### Features

* support `MaterialToggle`, `Enum`, `IntSlider` and `PowerSlider` shader property attributes ([9881112](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/988111243dbe81d9f19af9cc87136b9c02ba631b))
* use a searchable dropdown instead of a popup for property selection ([ca62a19](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/ca62a19627d5c9ff4be9093a0745feba1df349de)), closes [#6](https://github.com/mob-sakai/UIMaterialPropertyInjector/issues/6)

## [1.0.4](https://github.com/mob-sakai/UIMaterialPropertyInjector/compare/1.0.3...1.0.4) (2025-01-28)


### Bug Fixes

* vector4 properties such as `_MainTex_ST` cannot be modified from the Inspector in editor ([5805fd8](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/5805fd8ec5f0b0167d7dcda2ca5f378c4fa26506))

## [1.0.3](https://github.com/mob-sakai/UIMaterialPropertyInjector/compare/1.0.2...1.0.3) (2024-10-02)


### Bug Fixes

* make several APIs virtual for inheritance purposes. ([a6d57d2](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/a6d57d27fb69ecd793c5ba8092eb1c1784f8d92b))
* property changes by AnimationClip are not applied on the frame where the GameObject is activated in the editor ([35d9d20](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/35d9d2035e39e0ad3991947530698015fb10ac8f))
* when pressing the "add" button in the Tweener inspector, an error occurs. ([c661bcd](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/c661bcdb3b74f16f6df4894c0f26951c2162c345))

## [1.0.2](https://github.com/mob-sakai/UIMaterialPropertyInjector/compare/1.0.1...1.0.2) (2024-07-03)


### Bug Fixes

* nest less-frequently used properties within dropdown (editor) ([ad67744](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/ad67744c0525a1c3f2be7dcc7ccea94084d2b914))

## [1.0.1](https://github.com/mob-sakai/UIMaterialPropertyInjector/compare/1.0.0...1.0.1) (2024-07-01)


### Bug Fixes

* material properties do not change when Mask is disabled ([5bd37cd](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/5bd37cd41f8500417d717484d8439667e5cae0a1)), closes [#1](https://github.com/mob-sakai/UIMaterialPropertyInjector/issues/1)
* the background color of the inspector does not change while previewing or recording in the animation view ([6ea719f](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/6ea719f13270f08bb6e467831f16096f6bbd88a6)), closes [#2](https://github.com/mob-sakai/UIMaterialPropertyInjector/issues/2)

# 1.0.0 (2024-06-27)


### Features

* first release ([c6c8985](https://github.com/mob-sakai/UIMaterialPropertyInjector/commit/c6c8985857e3be807e8e392120925b1e036c094d))
