// .vitepress/theme/index.js
import DefaultTheme from 'vitepress/theme'
import PdfLayout from './PdfLayout.vue'

export default {
  extends: DefaultTheme,
  // override the Layout with a wrapper component that
  // injects the slots
  Layout: PdfLayout
}