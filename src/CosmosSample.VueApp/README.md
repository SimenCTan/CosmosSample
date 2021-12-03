# vue-demo

## 环境配置
- 本地开发  
本地开发时，请将.env.development中的AzFunction的地址

```bash
cors的问题在az function项目local.settings.json文件配置
"Host": {
    "LocalHttpPort": 7071,
    "CORS": "*"
}
```

## vue-demo 运行
npm install
npm run dev

## 发布

```bash
# 构建测试环境
npm run build:stage

# 构建生产环境
npm run build:prod
```

## 其它

```bash
# 预览发布环境效果
npm run preview

# 预览发布环境效果 + 静态资源分析
npm run preview -- --report

# 代码格式检查
npm run lint

# 代码格式检查并自动修复
npm run lint -- --fix
```

[参考地址](http://panjiachen.github.io/vue-admin-template)
