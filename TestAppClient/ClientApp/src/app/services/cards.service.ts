import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BaseHttpService } from ".";
import { Card } from "../models";

@Injectable()
export class CardsService extends BaseHttpService {
    private endpoint = `cards`

	constructor(
		httpClient: HttpClient
	) {
        super(httpClient);
    }

	public async getAllCards(): Promise<Card[]> {
		return await this.httpGet("cards");
	}

	public async getCardsByUser(userId: number): Promise<Card[]> {
		return await this.httpGet("cards-by-user");
	}

	public async saveCard(card: Card): Promise<Card[]> {
		return await this.httpPost("save-card", { card: card });
	}

	public async deleteCard(card: Card): Promise<Card[]> {
		return await this.httpDelete("delete-card", { card: card });
	}

	public async editCard(card: Card): Promise<Card[]> {
		return await this.httpPut("update-card", { card: card });
	}
}