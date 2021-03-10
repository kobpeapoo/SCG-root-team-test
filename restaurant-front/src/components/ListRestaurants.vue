<template>
  <div class="div container-fluid">
    <div class="row">
      <div class="col-sm-4">
        <form >
          <div class="form-group">
            <div class="input-group">
              <input type="text" class="form-control" placeholder="Place name" aria-label="Place name" aria-describedby="basic-addon2" v-model="inputData" />
              <div class="input-group-append">
                <button
                  class="btn btn-outline-secondary btn-primary btnFontColor"
                  type="submit" v-on:click="onSubmit">
                  Search
                </button>
              </div>
            </div>
          </div>
        </form>
      </div>
    </div>
    <div class="row">
      <div class="col-sm-12">
        <div class="table-responsive-sm">
          <table class="table">
            <caption>
              List of the resrtaurants at
              {{ inputData }}
            </caption>
            <thead>
              <tr>
                <th scope="col" style="width:5%">#</th>
                <th scope="col" style="width:20%">Restaurant Name</th>
                <th scope="col" style="width:30%">Address</th>
                <th scope="col" style="width:10%">location</th>
                <th scope="col" style="width:10%">Open</th>
                <th scope="col" style="width:10%">rating</th>
                <th scope="col" style="width:10%">user ratings total</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(rest, index) in restaurantResp" :key="index">
                <td>{{ index + 1 }}</td>
                <td>{{ rest.name }}</td>
                <td>{{ rest.formatted_address }}</td>
                <td>
                  Lat: {{ rest.geometry.location.lat }} <br />Long:
                  {{ rest.geometry.location.lng }}
                </td>
                <td>
                  <div v-if="rest.opening_hours !== null">
                  <p v-if="rest.opening_hours.open_now">
                    <button type="button" class="btn btn-success">Open</button>
                  </p>
                  <p v-else>
                    <button type="button" class="btn btn-warning">Closed</button>
                  </p>
                  </div>
                    <div v-else>
                      <button type="button" class="btn btn-warning">Closed</button>
                    </div>
                </td>
                <td>{{ rest.rating }}</td>
                <td>{{ rest.user_ratings_total }}</td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import Vue from 'vue'
// ประกาศ Axios
import VueAxios from 'vue-axios'
import axios from 'axios'
// เรียกใช้
Vue.use(VueAxios, axios)

export default {
/*eslint-disable */
  data () {
    return {
      inputData: 'Bang Sue',
      restaurantResp: []
    }
  },
  methods: {
    onSubmit () {
		this.retiveData(this.inputData)
	},
	testFunc() {
		console.log('Test Func')
	},
	retiveData(areaName){
		//Edit Host for your computer if run on production will use configuration file (http://localhost:60009)
		Vue.axios
			.get('http://localhost:60009/api/Restaurant/' + areaName, {headers: {'Content-Type': 'application/json'}
			}
			)
			.then((resp) => {
				this.restaurantResp = resp.data.Value.results
			})
		this.inputData = areaName
	}
  },
  mounted () {
	this.retiveData(this.inputData)
  }
}
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.div {
  margin-top: 150px;
}
.btnFontColor {
  color: white;
}
td {
  text-align: left;
  overflow: hidden;
}
</style>
