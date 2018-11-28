<template>
  <div>
    <page-title title="Give the Extensions" />
    <p>He you will be finding your loaded extensions:</p>
    <ul>
      <li v-for="(data, idx) in numbers" :key="idx">{{data.id}}
          <ul>
            <li>{{data.value}}</li>
          </ul>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  data () {
    return {
      numbers: []
    }
  },

  mounted() {
    this._getNumbers()
  },

  methods: {
    async _getNumbers () {
      let response = await this.$http.get(`api/values`)
      this.numbers = response.data
    }
  }
}
</script>
