<template>
  <div class="chart-container" />
</template>

<script>
import echarts from "echarts";
import { symbolApi } from "@/api/symbol";
export default {
  name: "Dashboard",
  data() {
    return {
      loading: true,
      chart: null,
      symbolDailyQuote: []
    };
  },
  watch: {
    symbolDailyQuote: {
      handler: function(val, oldval) {
        console.log(oldval);
        this.setOptions(val);
      },
      deep: true
    }
  },
  created() {
    this.getListInfo("000001.SZ");
  },
  mounted() {
    this.$nextTick(() => {
      this.initChart();
    });
  },
  beforeDestroy() {
    if (!this.chart) {
      return;
    }
    this.chart.dispose();
    this.chart = null;
  },
  methods: {
    getListInfo(tscode) {
      this.loading = true;
      symbolApi.GetDailyQuote(tscode).then((x) => {
        this.symbolDailyQuote = x.data;
        console.log(tscode);
        console.log(this.symbolDailyQuote)
        this.loading = false;
      });
    },
    initChart() {
      this.chart = echarts.init(this.$el);
      this.setOptions(this.symbolDailyQuote);
    },
    setOptions(actualData) {
      this.chart.setOption({
        // backgroundColor: "#141a1f",
        title: {
          text: "日线行情",
          x: "20",
          top: "20",
          textStyle: {
            color: "#fff",
            fontSize: "22"
          },
          subtextStyle: {
            color: "#90979c",
            fontSize: "16"
          }
        },
        tooltip: {
          trigger: "axis",
          axisPointer: {
            textStyle: {
              color: "#fff"
            }
          }
        },
        legend: {},
        dataset: {
          // 用 dimensions 指定了维度的顺序。直角坐标系中，如果 X 轴 type 为 category，
          // 默认把第一个维度映射到 X 轴上，后面维度映射到 Y 轴上。
          // 如果不指定 dimensions，也可以通过指定 series.encode
          dimensions: ['tradeDay', 'open', 'close', 'high', 'low'],
          source: actualData
        },
        xAxis: {
          type: "category",
          axisLine: { lineStyle: { color: '#777' }},
          axisPointer: { label: { show: false }},
          min: 'dataMin',
          max: 'dataMax',
          splitLine: {
            show: false
          },
          axisLabel: {
            interval: 0
          },
        },
        yAxis:
        {
          type: "value",
          scale: true,
          boundaryGap: ['5%', '5%'],
          splitLine: {
            show: false
          },
          axisLine: {
            lineStyle: {
              color: "#90979c"
            }
          },
          axisTick: {
            show: false
          },
          axisLabel: {
            interval: 0
          },
          splitArea: {
            show: false
          },
        },
        series: [
          {
            name: "日线行情",
            type: "candlestick",
            barMaxWidth: 5,
            barGap: "10%",
            itemStyle: {
              normal: {
                color: "rgba(0,191,183,1)",
                label: {
                  show: true,
                  textStyle: {
                    color: "#fff"
                  },
                  position: "insideTop",
                  formatter(p) {
                    return p.value > 0 ? p.value : "";
                  }
                }
              }
            },
            encode: {
              x: "tradeDay",
              y: ["open", "close", "low", "high"],
              tooltip: ["open", "high", "low", "close"]
            },
          },
        ]
      });
    }
  }
};
</script>

<style lang="scss" scoped>
.dashboard {
  &-container {
    margin: 30px;
  }
  &-text {
    font-size: 30px;
    line-height: 46px;
  }
}
.chart-container{
  position: relative;
  width: calc(200vh - 84px);;
  height: calc(100vh - 84px);
  margin: 30px;
}
</style>
