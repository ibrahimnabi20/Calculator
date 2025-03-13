import http from "k6/http";
import { check, sleep } from "k6";

export let options = {
    vus: 10,
    duration: "10s",
};

export default function () {
    let res = http.get("http://localhost:5000/api/calculator/history");

    check(res, {
        "is status 200": (r) => r.status === 200,
    });

    sleep(1);
}
