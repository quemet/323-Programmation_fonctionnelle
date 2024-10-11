import { defineConfig } from 'vitepress'
import {glob} from 'glob'
import path from 'path'

// https://vitepress.dev/reference/site-config
export default defineConfig({
  title: "ICT-323 Fun",
  description: "Module ICT 323 sur la programmation fonctionnelle",
  themeConfig: {
    // https://vitepress.dev/reference/default-theme-config
    nav: [
      { text: 'Home', link: '/' },
      { text: 'Séquences', link: '/sequences/01.md' }
    ],

    sidebar: [
      {
        text: 'Séquences',
        collapsed : false,
        items: Array.from({ length: 8 }, (_, i) => ({ text: `sequence ${i+1}`, link: `/sequences/0${i+1}` }))
      },
      {
        text: 'Supports',
        collapsed : true,
        items: glob.sync('supports/**/*.md',{posix:true})
          .map(f => '/' + f)
          .map((file) => ({ text: `${path.basename(file).replace(".md","")}`, link: `${file}` })).reverse()
      }
      ,
      {
        text: 'Exos',
        collapsed : true,
        items: glob.sync(['exos/*/README.md','exos/*/enoncé.md'],{posix:true})
          .map(f => '/' + f)
          .map((file) => ({ text: `${file.split("/")[2]}`, link: `${file.replace("README","index")}` })).reverse()
      }
      
    ],

    socialLinks: [
      { icon: 'github', link: '{REPO_URL}' }
    ],
    search: {
      provider: 'local'
    }
  },
  ignoreDeadLinks: true,
  base: "/323-Programmation_fonctionnelle/",//for gh pages
  
  rewrites: {
    'README.md': 'index.md',
  },
})
