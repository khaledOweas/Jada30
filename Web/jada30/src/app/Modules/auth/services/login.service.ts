import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { AppConfigService } from "../../../Core/Services/app-config.service";

@Injectable({
  providedIn: "root"
})
export class LoginService {
  constructor(private http: HttpClient, private configService: AppConfigService) {
    const config = this.configService.getConfig();
    console.log("API URL:", config.apiUrl);
    console.log("Auth Endpoint:", config.authEndpoint);
    console.log("Feature Flag:", config.featureFlags.enableNewFeature);
  }

  login(username: string, password: string): Observable<any> {
    const headers = new HttpHeaders({
      "Content-Type": "application/x-www-form-urlencoded"
    });

    const body = new HttpParams()
      .set("grant_type", "password")
      .set("client_id", "Jada-30.api.local")
      .set("username", username)
      .set("password", password)
      .set("scope", "read openid offline_access")
      .set("aud", "Jada30APIGetWay");

    return this.http.post<any>(this.configService.getConfig().authEndpoint, body.toString(), { headers });
  }
}
